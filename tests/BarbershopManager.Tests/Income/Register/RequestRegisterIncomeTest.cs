using BarbershopManager.Application.UseCases.Faturamento.Register;
using BarbershopManager.Tests;
using FluentAssertions;

namespace ValidatorTests.Income.Register;
public class RequestRegisterIncomeTest
{
    [Fact]
    public void Tests_With_Name_Success()
    {
        //Arrange
        var validator = new RequestRegisterIncomeValidator();
        var request = RequestRegisterIncomeBuilder.Build();

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeTrue();

    }
}
