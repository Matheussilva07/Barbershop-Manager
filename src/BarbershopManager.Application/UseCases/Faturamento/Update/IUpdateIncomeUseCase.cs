using BarbershopManager.Communication.Requests;

namespace BarbershopManager.Application.UseCases.Faturamento.Update;
public interface IUpdateIncomeUseCase
{
	Task Execute(int id, RequestUpdateIncomeJson request);
}
