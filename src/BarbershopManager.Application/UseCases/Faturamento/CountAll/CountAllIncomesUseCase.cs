using BarbershopManager.Domain.IncomeRepository;
using BarbershopManager.Domain.Services;

namespace BarbershopManager.Application.UseCases.Faturamento.CountAll;
internal class CountAllIncomesUseCase : ICountAllIncomesUseCase
{
    private readonly IIncomesRepository _repository;
    private readonly ILoggedUser _loggedUser;
	public CountAllIncomesUseCase(IIncomesRepository repository, ILoggedUser loggedUser)
	{
		_repository = repository;
		_loggedUser = loggedUser;
	}
	public async Task<int> Execute()
	{
		var loggedUser = await _loggedUser.GetUser();

		var totalIncomes = await _repository.CountAll(loggedUser);

        return totalIncomes;
	}
}
