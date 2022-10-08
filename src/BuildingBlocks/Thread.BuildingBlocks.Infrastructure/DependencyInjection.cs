using Thread.BuildingBlocks.Infrastructure.EmailSender;

namespace Thread.BuildingBlocks.Infrastructure;

public static class DependencyInjection
{
    public static void AddBuildingBlocks(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IDomainEventsDispatcher, DomainEventsDispatcher.DomainEventsDispatcher>();
        services.AddScoped<IEmailSender, EmailSender.EmailSender>();
        
        services.AddSingleton(configuration.GetSection(SmtpConfiguration.SECTION_NAME).Get<SmtpConfiguration>());
        
        services.AddMediatR(Assembly.Load("Thread.BuildingBlocks.Infrastructure"));
    }
}