namespace Thread.Api.Start;

internal static class Startup
{
    internal static Logger ConfigureLogger() => new LoggerConfiguration()
        .WriteTo.File(
            rollingInterval: RollingInterval.Day,
            restrictedToMinimumLevel: LogEventLevel.Error,
            formatter: new JsonFormatter(),
            path: "log/log.txt")
        .WriteTo.Console(
            restrictedToMinimumLevel: LogEventLevel.Information)
        .CreateLogger();

    internal static void ConfigureHost(ConfigureHostBuilder host)
    {
        host.UseSerilog();
    }

    internal static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddBuildingBlocks(configuration);
        services.AddUserAccessModule(configuration);
        services.AddJwtAuth(configuration);
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerDoc();
    }

    internal static void ConfigureWebApp(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseSerilogRequestLogging();

        app.UseCustomProblemDetails();

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseSwaggerDoc();

        app.MapControllers();
    }
}