namespace Thread.Modules.UserAccess.Infrastructure.Persistence;

internal sealed class UserAccessDbContextDesignTimeFactory : IDesignTimeDbContextFactory<UserAccessDbContext>
{
    public UserAccessDbContext CreateDbContext(string[] args)
    {
        var connection = args[0];

        var optionsBuilder = new DbContextOptionsBuilder<UserAccessDbContext>();
        optionsBuilder.UseSqlServer(connection);

        return new UserAccessDbContext(optionsBuilder.Options, default);
    }
}