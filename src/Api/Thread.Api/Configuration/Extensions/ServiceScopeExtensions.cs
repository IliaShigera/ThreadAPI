namespace Thread.Api.Configuration.Extensions;

internal static class ServiceScopeExtensions
{
    internal static async Task MigrateAllDatabasesSqlServerAsync(this IServiceProvider serviceProvider)
    {
        await serviceProvider.MigrateUserAccessDatabaseSqlServerAsync();
    }
}