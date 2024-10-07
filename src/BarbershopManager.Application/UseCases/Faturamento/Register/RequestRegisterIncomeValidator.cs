using BarbershopManager.Communication.Requests;
using FluentValidation;

namespace BarbershopManager.Application.UseCases.Faturamento.Register;
public class RequestRegisterIncomeValidator : AbstractValidator<RequestRegisterIncomeJson>
{
    public RequestRegisterIncomeValidator()
    {
        RuleFor(income => income.Nome).NotEmpty().WithMessage("Preencha o nome!");
        RuleFor(income => income.Data_Servico).LessThan(DateTime.Now.AddYears(2)).WithMessage("Defina a data do serviço!");
        RuleFor(income => income.Tipo_Servico).IsInEnum().WithMessage("Serviço inválido!");
        RuleFor(income => income.Preco).GreaterThan(0).WithMessage("Valor inválido!");
        RuleFor(income => income.Tipo_Pagamento).IsInEnum().WithMessage("Tipo de pagamento inválido!");
    }
}
