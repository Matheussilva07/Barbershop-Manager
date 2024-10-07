using BarbershopManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BarbershopManager.Infrastructure.DataAccess;
public class BarbershopDbContext : DbContext
{
    public DbSet<Income> Incomes { get; set; }
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		string connectionString = "server = localhost; user = root; database = dbtestes; password = Kundschafter1996;";

		var version = new Version(8,0,39);

		var serverVersion = new MySqlServerVersion(version);

		optionsBuilder.UseMySql(connectionString, serverVersion);
	}
}
