

namespace Thread.Api.Start;

internal static class Startup
{
    public static Logger ConfigureLogger() => new LoggerConfiguration()
        .WriteTo.File(
            rollingInterval: RollingInterval.Day,
            restrictedToMinimumLevel: LogEventLevel.Error,
            formatter: new JsonFormatter(),
            path: "log/log.txt")
        .WriteTo.Console(
            restrictedToMinimumLevel: LogEventLevel.Information)
        .CreateLogger();


    public static void ConfigureHost(ConfigureHostBuilder host)
    {
        host.UseSerilog();
    }

    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        services.AddBuildingBlocks(configuration);
        services.AddUserAccessModule(configuration);
    }

    public static void ConfigureWebApp(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseSerilogRequestLogging();

        app.UseCustomProblemDetails();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
    }
}