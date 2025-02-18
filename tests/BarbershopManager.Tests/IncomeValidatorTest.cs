using BarbershopManager.Application.UseCases.Faturamento.Register;
using FluentAssertions;

namespace BarbershopManager.Tests;
public class IncomeValidatorTest
{
	[Fact]
	public void Tests_With_Name_Success()
	{
		//Arrange
		var validator = new RequestRegisterIncomeValidator();
		var request = RequestRegisterIncomeBuilder.Builder();

		//Act
		var result = validator.Validate(request);

		//Assert
		result.IsValid.Should().BeTrue();

	}
}
