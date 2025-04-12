using BarbershopManager.Application.UseCases.Users.Register;
using CommomUtilities.RequestsBuilder;
using FluentAssertions;

namespace ValidatorTests.User.Register;
public class RequestRegisterUserTest
{
	[Fact]
	public void Success()
	{
		var request = RequestRegisterUserBuilder.Build();

		var validator = new RegisterUserValidator();

		var result = validator.Validate(request);

		result.IsValid.Should().BeTrue();
		result.Errors.Should().BeEmpty();
	}

	[Theory]
	[InlineData("")]
	[InlineData("   ")]
	[InlineData(null)]
	public void Error_Name_Empty(string name)
	{
		var request = RequestRegisterUserBuilder.Build();
		request.Name = name;

		var validator = new RegisterUserValidator();

		var result = validator.Validate(request);

		result.IsValid.Should().BeFalse();
		result.Errors.Should().NotBeNullOrEmpty();
		result.Errors.Should().HaveCount(1);
	}

	[Fact]
	public void Error_Email_Invalid()
	{
		var request = RequestRegisterUserBuilder.Build();
		request.Email = "meuEmail.com";

		var validator = new RegisterUserValidator();

		var result = validator.Validate(request);

		result.IsValid.Should().BeFalse();
		result.Errors.Should().NotBeNullOrEmpty();
		result.Errors.Should().HaveCount(1).And.Contain(result.Errors.First(e => e.ErrorMessage.Equals("Email inválido!")));
	}
}
