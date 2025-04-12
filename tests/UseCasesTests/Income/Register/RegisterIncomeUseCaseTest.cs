using BarbershopManager.Application.UseCases.Faturamento.Register;
using BarbershopManager.Exception.ExceptionBase;
using BarbershopManager.Tests;
using CommomUtilities.EntitiesBuilder;
using CommomUtilities.Mocks;
using FluentAssertions;

namespace UseCasesTests.Income.Register;
public class RegisterIncomeUseCaseTest
{
	
	[Fact]
	public async Task Success()
	{
		var income = IncomeBuilder.GetIncome();
		var request = RequestRegisterIncomeBuilder.Build();

		var useCase = CreateUseCase(income);

		var response = await useCase.Execute(request);

		response.Nome.Should().NotBeNullOrEmpty();
		response.Data_Servico.Should().BeLessThan(TimeSpan.FromDays(5));
	}

	[Fact]
	public async Task Error_Name_Empty()
	{
		var income = IncomeBuilder.GetIncome();

		var request = RequestRegisterIncomeBuilder.Build();
		request.Nome = string.Empty;

		var useCase = CreateUseCase(income);

		var act = async () => await useCase.Execute(request);

		var result = await act.Should().ThrowAsync<ErrorOnValidationException>();

		result.Where(e => e.GetErrors().Count == 1 && e.GetErrors().Contains(ResourceErrorMessages.NOME_INVALIDO));
	}


	private RequestRegisterIncomeUseCase CreateUseCase(BarbershopManager.Domain.Entities.Income income)
	{		
		var unitOfWork = UnitOfWork_Mock.Build();
		var repository = IncomesRepository_mock.Build(income);
		var mapper = MapperBuilder.Build();

		return new RequestRegisterIncomeUseCase(mapper, unitOfWork, repository);
	}
}
