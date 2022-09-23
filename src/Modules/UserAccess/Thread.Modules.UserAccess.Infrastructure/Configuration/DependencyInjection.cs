namespace Thread.Modules.UserAccess.Infrastructure.Configuration;

public static class DependencyInjection
{
    public static void AddUserAccessModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUniqueUser, UniqueUser>();
        services.AddScoped<IUserAccessDbContext, UserAccessDbContext>();
        services.AddScoped<IPasswordManager, PasswordManager>();
        services.AddScoped<IEmailSender, EmailSender>();
        
        services.AddSingleton(configuration.GetSection(SmtpConfiguration.SECTION_NAME).Get<SmtpConfiguration>());

        var connection = configuration.GetConnectionString("UserAccess");
        services.AddDbContext<UserAccessDbContext>(options => options.UseSqlServer(connection));

        services.AddMediatR(Assembly.Load("Thread.Modules.UserAccess.Application"));
    }
}