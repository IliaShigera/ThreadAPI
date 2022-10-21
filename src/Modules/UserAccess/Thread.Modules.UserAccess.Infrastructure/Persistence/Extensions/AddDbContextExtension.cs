namespace Thread.Modules.UserAccess.Infrastructure.Persistence.Extensions;

internal static class AddDbContextExtension
{
    internal static void AddUserAccessDbContextDependingOnTheEnvironment(this IServiceCollection services, string connection)
    {
        if (HostEnvironment.IsDevelopment() || HostEnvironment.IsProduction())
        {
            services.AddDbContext<UserAccessDbContext>(options => options.UseSqlServer(connection));
        } 
        else if (HostEnvironment.IsTest())
        {
            services.AddDbContext<UserAccessDbContext>(options => options.UseSqlite(connection));
        }
    }
}