namespace Thread.Modules.UserAccess.Application.Features.Registration;

public sealed class RegisterUserCommand : ICommand
{
    public RegisterUserCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public string Email { get; }
    public string Password { get; }
}

internal sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand>
{
    private readonly IUserAccessDbContext _dbContext;
    private readonly IUniqueUser _uniqueUser;
    private readonly IPasswordManager _passwordManager;

    public RegisterUserCommandHandler(
        IUserAccessDbContext dbContext,
        IUniqueUser uniqueUser,
        IPasswordManager passwordManager)
    {
        _dbContext = dbContext;
        _uniqueUser = uniqueUser;
        _passwordManager = passwordManager;
    }

    public async Task<Unit> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        var passwordHash = _passwordManager.HashPassword(command.Password);
        
        var registration = UserRegistration.RegisterNewUser(command.Email, passwordHash, _uniqueUser);
        
        await _dbContext.Registrations.AddAsync(registration, cancellationToken);
        await _dbContext.CommitAsync(cancellationToken);

        return Unit.Value; 
    }
}