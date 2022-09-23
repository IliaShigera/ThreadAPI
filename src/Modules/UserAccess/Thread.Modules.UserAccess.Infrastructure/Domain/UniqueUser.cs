namespace Thread.Modules.UserAccess.Infrastructure.Domain;

public class UniqueUser: IUniqueUser
{
    private readonly IUserAccessDbContext _context;

    public UniqueUser(IUserAccessDbContext context)
    {
        _context = context;
    }

    public bool IsUniqEmail(string email)
    {
        return !_context.Registrations.Any(r => r.Email.Equals(email));
    }
}