Log.Logger = Startup.ConfigureLogger();

try
{
    Log.Information("Staring web host");
    
    var builder = WebApplication.CreateBuilder(args);
    builder.Configuration.AddJsonFile($"Configuration/AppSettings/appsettings.{HostEnvironment.EnvironmentType}.json");
    
    Startup.ConfigureHost(builder.Host);
    Startup.ConfigureWebHost(builder.WebHost);
    Startup.ConfigureServices(builder.Services, builder.Configuration);
    var app = builder.Build();
    Startup.ConfigureWebApp(app);
    
    if (HostEnvironment.IsDevelopment() || HostEnvironment.IsTest())
    {
        var scope = app.Services.CreateScope();
        await scope.ServiceProvider.MigrateAllDatabasesSqlServerAsync();
    }
    
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