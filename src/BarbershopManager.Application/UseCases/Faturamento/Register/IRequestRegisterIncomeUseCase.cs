using BarbershopManager.Communication.Requests;
using BarbershopManager.Communication.Responses;

namespace BarbershopManager.Application.UseCases.Faturamento.Register;
public interface IRequestRegisterIncomeUseCase
{
	Task<ResponseRegisteredIncomeJson> Execute(RequestRegisterIncomeJson request);
}
