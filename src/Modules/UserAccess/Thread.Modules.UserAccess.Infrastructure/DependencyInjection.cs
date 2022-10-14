namespace Thread.Modules.UserAccess.Infrastructure;

public static class DependencyInjection
{
    public static void AddUserAccessModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUniqueUser, UniqueUser>();
        services.AddScoped<IUserAccessDbContext, UserAccessDbContext>();
        services.AddScoped<IPasswordManager, PasswordManager>();
        services.AddScoped<IUserAccessModule, UserAccessModule>();
        services.AddScoped<ITokenClaimsService, JwtAuthClaimsService>();
        services.AddScoped<ILinkProvider, LinkProvider>();
        
        services.AddSingleton(configuration.GetSection(AuthorizationConfiguration.SECTION_NAME).Get<AuthorizationConfiguration>());
        services.AddSingleton(configuration.GetSection(LinkConfiguration.SECTION_NAME).Get<LinkConfiguration>());

        var connection = configuration.GetConnectionString("UserAccess");
        services.AddDbContext<UserAccessDbContext>(options => options.UseSqlServer(connection));

        services.AddMediatR(
            Assembly.Load("Thread.Modules.UserAccess.Application"),
            Assembly.Load("Thread.Modules.UserAccess.Infrastructure"));
    }
}