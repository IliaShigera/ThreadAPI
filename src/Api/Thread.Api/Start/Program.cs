Log.Logger = Startup.ConfigureLogger();

try
{
    Log.Information("Staring web host");

    var builder = WebApplication.CreateBuilder(args);
    builder.Configuration.AddJsonFile($"Configuration/AppSettings/appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json");
    Startup.ConfigureHost(builder.Host);
    Startup.ConfigureWebHost(builder.WebHost, builder.Configuration);
    Startup.ConfigureServices(builder.Services, builder.Configuration);
    var app = builder.Build();
    Startup.ConfigureWebApp(app);
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}