using BarbershopManager.Communication.Requests.Incomes;

namespace BarbershopManager.Application.UseCases.Faturamento.Update;
public interface IUpdateIncomeUseCase
{
	Task Execute(int id, RequestUpdateIncomeJson request);
}
