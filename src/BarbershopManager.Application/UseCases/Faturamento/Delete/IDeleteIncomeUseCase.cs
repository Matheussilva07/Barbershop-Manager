using BarbershopManager.Domain.Entities;

namespace BarbershopManager.Application.UseCases.Faturamento.Delete;
public interface IDeleteIncomeUseCase
{
	Task Execute(int id);
}
