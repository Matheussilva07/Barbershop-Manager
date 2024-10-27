using BarbershopManager.Communication.Requests;
using BarbershopManager.Exception.ExceptionBase;
using FluentValidation;

namespace BarbershopManager.Application.UseCases.Faturamento.Register;
public class RequestRegisterIncomeValidator : AbstractValidator<RequestRegisterIncomeJson>
{
    public RequestRegisterIncomeValidator()
    {
        RuleFor(income => income.Nome).NotEmpty().WithMessage(ResourceErrorMessages.NOME_INVALIDO);
        RuleFor(income => income.Data_Servico).LessThan(DateTime.Now.AddYears(2)).WithMessage(ResourceErrorMessages.DATA_INVALIDA);
        RuleFor(income => income.Tipo_Servico).IsInEnum().WithMessage(ResourceErrorMessages.SERVICO_INVALIDO);
        RuleFor(income => income.Preco).GreaterThan(0).WithMessage(ResourceErrorMessages.VALOR_INVALIDO);
        RuleFor(income => income.Tipo_Pagamento).IsInEnum().WithMessage(ResourceErrorMessages.PAGAMENTO_INVALIDO);
    }
}
