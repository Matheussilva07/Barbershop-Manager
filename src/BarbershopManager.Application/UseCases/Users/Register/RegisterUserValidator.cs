using BarbershopManager.Communication.Requests.Users;
using FluentValidation;

namespace BarbershopManager.Application.UseCases.Users.Register;
public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
{
    public RegisterUserValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage("Preencha o nome!");
        RuleFor(user => user.Email).NotEmpty().WithMessage("Preencha seu email!").EmailAddress().WithMessage("Email inválido!");
        RuleFor(user => user.Password).SetValidator(new PasswordValidator<RequestRegisterUserJson>());
    }
}
