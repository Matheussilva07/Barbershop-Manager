using BarbershopManager.Application.UseCases.Faturamento.Register;
using BarbershopManager.Communication.Requests;

namespace BarbershopManager.Tests;

public class UnitTest1
{
	[Fact]
	public void Test1()
	{

		var validator = new RequestRegisterIncomeValidator();
		var request = new RequestRegisterIncomeJson();

		var result = validator.Validate(request).IsValid;

		Assert.True(result);
	}


	
}