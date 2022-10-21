namespace Thread.Modules.UserAccess.Infrastructure.Persistence;

internal sealed class UserAccessDbContextDesignTimeFactory : IDesignTimeDbContextFactory<UserAccessDbContext>
{
    public UserAccessDbContext CreateDbContext(string[] args)
    {
        var envType = args.FirstOrDefault(x => x.StartsWith("env"));

        if (envType is null)
        {
            throw new ArgumentException("Argument \'env\' is not exist. Available env types:" +
                                        $" \'{HostEnvironment.Development}\', " +
                                        $"\'{HostEnvironment.Production}\', " +
                                        $"\'{HostEnvironment.Test}\'. " +
                                        "Example: -- env-Development");
        }

        envType = new string(envType.Split('-')[1]);

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(@$"{Directory.GetCurrentDirectory()}\..\..\..\Api\Thread.Api\Configuration\AppSettings")
            .AddJsonFile($"appsettings.{envType}.json")
            .Build();

        var connection = configuration.GetConnectionString("UserAccess");
        var optionsBuilder = new DbContextOptionsBuilder<UserAccessDbContext>();

        if (String.Equals(envType, HostEnvironment.Development) || String.Equals(envType, HostEnvironment.Production))
        {
            optionsBuilder.UseSqlServer(connection);
        }
        else if (String.Equals(envType, HostEnvironment.Test))
        {
            optionsBuilder.UseSqlite(connection);
        }
        
        return new UserAccessDbContext(optionsBuilder.Options, default);
    }
}