using BarbershopManager.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BarbershopManager.Infrastructure.Migrations;
public class MigrationsApllyCommand
{
    public static async Task ApllyMigration(IServiceProvider serviceProvider)
    {
        var scope = serviceProvider.CreateAsyncScope();

        var db = scope.ServiceProvider.GetRequiredService<BarbershopDbContext>();

        await db.Database.MigrateAsync();
    }
}
