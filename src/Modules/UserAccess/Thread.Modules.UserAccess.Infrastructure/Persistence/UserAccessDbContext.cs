namespace Thread.Modules.UserAccess.Infrastructure.Persistence;

internal sealed class UserAccessDbContext : DbContext, IUserAccessDbContext
{
    public UserAccessDbContext(DbContextOptions<UserAccessDbContext> options)
        : base(options)
    {
    }

    public DbSet<UserRegistration> Registrations { get; private set; }

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        await SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}