using BarbershopManager.Communication.Responses;

namespace BarbershopManager.Application.UseCases.Faturamento.GetById;
public interface IGetIncomeByIdUseCase
{
	Task<ResponseIncomeJson> Execute(int id);
}
