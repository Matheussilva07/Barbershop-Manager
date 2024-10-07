using BarbershopManager.Communication.Responses;

namespace BarbershopManager.Application.UseCases.Faturamento.GetAll;
public interface IGetAllIncomesUseCase
{
	Task<ResponsesIncomesListJson> Execute();
}
