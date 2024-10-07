using BarbershopManager.Infrastructure.DataAccess;
using Microsoft.Extensions.DependencyInjection;

namespace BarbershopManager.Infrastructure;
public static class DependencyInjectionExtension
{
	public static void AddInfrastructure(this IServiceCollection services)
	{
		services.AddScoped<BarbershopDbContext>();
	}
	private static void DependencyInjections(IServiceCollection services)
	{

	}
}

