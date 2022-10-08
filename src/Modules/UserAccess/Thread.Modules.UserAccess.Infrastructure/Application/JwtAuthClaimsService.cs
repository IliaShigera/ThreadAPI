namespace Thread.Modules.UserAccess.Infrastructure.Application;

internal sealed class JwtAuthClaimsService : ITokenClaimsService
{
    private readonly AuthorizationConfiguration _configuration;

    public JwtAuthClaimsService(AuthorizationConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public string GenerateAuthToken(ApplicationUser user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration.JwtSecretKey);
        
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, user.Email),
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims.ToArray()),
            Expires = DateTime.UtcNow.AddDays(_configuration.ExpiresDays),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}