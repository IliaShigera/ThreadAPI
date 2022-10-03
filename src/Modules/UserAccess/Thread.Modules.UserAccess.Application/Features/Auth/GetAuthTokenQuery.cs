namespace Thread.Modules.UserAccess.Application.Features.Auth;

public sealed record GetAuthTokenQuery(string Email, string Password) : IQuery<AuthResultDto>;

internal sealed class GetAuthTokenQueryHandler : IQueryHandler<GetAuthTokenQuery, AuthResultDto>
{
    private readonly IUserAccessDbContext _dbContext;
    private readonly IPasswordManager _passwordManager;
    private readonly ITokenClaimsService _tokenClaimsService;

    public GetAuthTokenQueryHandler(
        IUserAccessDbContext dbContext,
        IPasswordManager passwordManager,
        ITokenClaimsService tokenClaimsService)
    {
        _dbContext = dbContext;
        _passwordManager = passwordManager;
        _tokenClaimsService = tokenClaimsService;
    }
    
    public async Task<AuthResultDto> Handle(GetAuthTokenQuery query, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Email.Equals(query.Email), cancellationToken);

        if (user is null)
            throw new SpecNotFoundException($"User with email: {query.Email} not exists.", nameof(ApplicationUser));

        var isVerifiedPassword = _passwordManager.VerifyHashedPassword(user.PasswordHash, query.Password);
        if (!isVerifiedPassword)
            throw new InvalidPasswordException("Password is invalid.");

        var token = _tokenClaimsService.GenerateAuthToken(user);
        
        return new AuthResultDto(token);
    }
} 