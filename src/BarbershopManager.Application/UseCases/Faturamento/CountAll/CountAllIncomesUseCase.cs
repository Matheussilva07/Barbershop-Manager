using BarbershopManager.Domain.IncomeRepository;

namespace BarbershopManager.Application.UseCases.Faturamento.CountAll;
internal class CountAllIncomesUseCase : ICountAllIncomesUseCase
{
    private readonly IIncomesRepository _repository;
    public CountAllIncomesUseCase(IIncomesRepository repository)
    {
        this._repository = repository;
    }
    public async Task<int> Execute()
	{
        var totalIncomes = await _repository.CountAll();

        return totalIncomes;

	}
}
