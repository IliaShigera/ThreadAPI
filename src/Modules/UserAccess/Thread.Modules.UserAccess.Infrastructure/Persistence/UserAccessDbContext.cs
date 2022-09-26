

namespace Thread.Modules.UserAccess.Infrastructure.Persistence;

internal sealed class UserAccessDbContext : DbContext, IUserAccessDbContext
{
    private readonly IDomainEventsDispatcher _domainEventsDispatcher;

    public UserAccessDbContext(DbContextOptions<UserAccessDbContext> options, IDomainEventsDispatcher domainEventsDispatcher) 
        : base(options)
    {
        _domainEventsDispatcher = domainEventsDispatcher;
    }
    
    public DbSet<UserRegistration> Registrations { get; private set; }

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        await SaveChangesAsync(cancellationToken);

        await _domainEventsDispatcher.DispatchDomainEventsAsync(this, cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}