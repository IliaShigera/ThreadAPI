Log.Logger = Startup.ConfigureLogger();

try
{
    Log.Information("Staring web host");
    
    var builder = WebApplication.CreateBuilder(args);
    Startup.ConfigureHost(builder.Host);
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