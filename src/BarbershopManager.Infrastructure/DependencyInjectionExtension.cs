using BarbershopManager.Domain.IncomeRepository;
using BarbershopManager.Domain;
using BarbershopManager.Infrastructure.DataAccess;
using BarbershopManager.Infrastructure.IncomeRepository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BarbershopManager.Infrastructure;
public static class DependencyInjectionExtension
{
	public static void AddInfrastructureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
	{
		DependencyInjections(services);
		AddDbContext(services, configuration);
	}
	private static void DependencyInjections(IServiceCollection services)
	{
		services.AddScoped<BarbershopDbContext>();
		services.AddScoped<IIncomesRepository, IncomesRepository>();
		services.AddScoped<IUpdateRepository, IncomesRepository>();
		services.AddScoped<IUnitOfWork, UnitOfWork>();
	}
	private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
	{
		var version = new Version(8, 0, 39);
		var serverVersion = new MySqlServerVersion(version);

		services.AddDbContext<BarbershopDbContext>(config => config.UseMySql(configuration.GetConnectionString("Connection"),serverVersion));
	}
}

