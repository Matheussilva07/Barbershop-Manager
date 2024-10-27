using BarbershopManager.Domain.IncomeRepository;
using BarbershopManager.Domain;
using BarbershopManager.Infrastructure.DataAccess;
using BarbershopManager.Infrastructure.IncomeRepository;
using Microsoft.Extensions.DependencyInjection;

namespace BarbershopManager.Infrastructure;
public static class DependencyInjectionExtension
{
	public static void AddInfrastructureDependencyInjection(this IServiceCollection services)
	{
		DependencyInjections(services);
	}
	private static void DependencyInjections(IServiceCollection services)
	{
		services.AddScoped<BarbershopDbContext>();
		services.AddScoped<IIncomesRepository, IncomesRepository>();
		services.AddScoped<IUpdateRepository, IncomesRepository>();
		services.AddScoped<IUnitOfWork, UnitOfWork>();
	}
}

