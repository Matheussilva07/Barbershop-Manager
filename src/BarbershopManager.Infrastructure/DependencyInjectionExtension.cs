using BarbershopManager.Domain.IncomeRepository;
using BarbershopManager.Domain;
using BarbershopManager.Infrastructure.DataAccess;
using BarbershopManager.Infrastructure.IncomeRepository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using BarbershopManager.Domain.UsersRepository;
using BarbershopManager.Infrastructure.UsersRepository;
using BarbershopManager.Domain.Security.Cryptography;
using BarbershopManager.Infrastructure.Security.Cryptography;
using BarbershopManager.Domain.Security.Token;
using BarbershopManager.Infrastructure.Security.Token;
using BarbershopManager.Domain.Services;
using BarbershopManager.Infrastructure.Services;

namespace BarbershopManager.Infrastructure;
public static class DependencyInjectionExtension
{
	public static void AddInfrastructureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
	{
		DependencyInjections(services);
		AddDbContext(services, configuration);
		AddTokenGenerator(services, configuration);
	}
	private static void DependencyInjections(IServiceCollection services)
	{
		services.AddScoped<BarbershopDbContext>();
		services.AddScoped<IIncomesRepository, IncomesRepository>();
		services.AddScoped<IUpdateRepository, IncomesRepository>();
		services.AddScoped<IUnitOfWork, UnitOfWork>();
		services.AddScoped<IEncryptor, Encryptor>();

		services.AddScoped<IReadOnlyUserRepository, UserRepository>();
		services.AddScoped<IWriteOnlyUserRepository, UserRepository>();

		services.AddScoped<ILoggedUser, LoggedUser>();
	}

	private static void AddTokenGenerator(IServiceCollection services, IConfiguration configuration)
	{
		var signingKey = configuration.GetValue<string>("Settings:Jwt:signingKey");
		var expirationTimeMinutes = configuration.GetValue<uint>("Settings:Jwt:expirationTimeMinute");

		services.AddScoped<IJwtTokenGenerator>(config => new JwtTokenGenerator(signingKey!, expirationTimeMinutes));
	}
	private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
	{
		string connectionSring = configuration.GetConnectionString("Connection")!;

		var version = new Version(8, 0, 39);
		var serverVersion = new MySqlServerVersion(version);

		services.AddDbContext<BarbershopDbContext>(config => config.UseMySql(connectionSring, serverVersion));
	}
}

