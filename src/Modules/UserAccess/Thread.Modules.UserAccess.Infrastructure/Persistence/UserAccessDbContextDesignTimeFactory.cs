namespace Thread.Modules.UserAccess.Infrastructure.Persistence;

internal sealed class UserAccessDbContextDesignTimeFactory : IDesignTimeDbContextFactory<UserAccessDbContext>
{
    public UserAccessDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(@$"{Directory.GetCurrentDirectory()}\..\..\..\Api\Thread.Api")
            .AddJsonFile("appsettings.json")
            .Build();

        var connection = configuration.GetConnectionString("UserAccess");
        
        var optionsBuilder = new DbContextOptionsBuilder<UserAccessDbContext>();
        optionsBuilder.UseSqlServer(connection);
        
        return new UserAccessDbContext(optionsBuilder.Options, default);
    }
}