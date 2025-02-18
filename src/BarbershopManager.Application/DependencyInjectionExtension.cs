using BarbershopManager.Application.UseCases.Faturamento.CountAll;
using BarbershopManager.Application.UseCases.Faturamento.CountByMonth;
using BarbershopManager.Application.UseCases.Faturamento.Delete;
using BarbershopManager.Application.UseCases.Faturamento.GetAll;
using BarbershopManager.Application.UseCases.Faturamento.GetById;
using BarbershopManager.Application.UseCases.Faturamento.Register;
using BarbershopManager.Application.UseCases.Faturamento.Reports.Excel;
using BarbershopManager.Application.UseCases.Faturamento.Update;
using BarbershopManager.Application.UseCases.Users.GetProfile;
using BarbershopManager.Application.UseCases.Users.Login;
using BarbershopManager.Application.UseCases.Users.Register;
using Microsoft.Extensions.DependencyInjection;

namespace BarbershopManager.Application;
public static class DependencyInjectionExtension
{
	public static void AddUseCasesDependencyInjection(this IServiceCollection services)
	{
		AddUseCase(services);
	}

	private static void AddUseCase(IServiceCollection services)
	{
		services.AddScoped<IGetIncomeByIdUseCase, GetIncomeByIdUseCase>();
		services.AddScoped<IRequestRegisterIncomeUseCase, RequestRegisterIncomeUseCase>();
		services.AddScoped<IGetAllIncomesUseCase, GetAllIncomesUseCase>();
		services.AddScoped<IUpdateIncomeUseCase, UpdateIncomeUseCase>();
		services.AddScoped<IDeleteIncomeUseCase, DeleteIncomeUseCase>();

		services.AddScoped<ICountAllIncomesUseCase, CountAllIncomesUseCase>();
		services.AddScoped<ICountByMonthUseCase, CountByMonthUseCase>();

		services.AddScoped<IGenerateExcelReportUseCase, GenerateExcelReportUseCase>();

		services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
		services.AddScoped<IDoLoginUseCase, DoLoginUseCase>();
		services.AddScoped<IGetProfileUserUseCase, GetProfileUserUseCase>();


	}
}
