namespace Thread.Modules.UserAccess.Infrastructure.Persistence.Extensions;

public static class AutoMigrationExtension
{
    public static async Task MigrateUserAccessDatabaseSqlServerAsync(this IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<UserAccessDbContext>();

        if (context.Database.IsSqlServer())
        {
            await context.Database.MigrateAsync();
            // seed db
        }
    }
}