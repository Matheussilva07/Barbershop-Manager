using BarbershopManager.Domain.IncomeRepository;
using BarbershopManager.Domain.Services;
using BarbershopManager.Exception.ExceptionBase;

namespace BarbershopManager.Application.UseCases.Faturamento.CountByMonth;
public class CountByMonthUseCase : ICountByMonthUseCase
{
    private readonly IIncomesRepository _repository;
    private readonly ILoggedUser _loggedUser;
	public CountByMonthUseCase(IIncomesRepository repository, ILoggedUser loggedUser)
	{
		_repository = repository;
		_loggedUser = loggedUser;
	}
	public async Task<int> Execute(DateOnly month)
	{
		var loggedUser = await _loggedUser.GetUser();

		var total = await _repository.CountAllInMonth(month, loggedUser);

        if (total == 0)
        {
            throw new NotFoundException(ResourceErrorMessages.NAO_ENCONTRADO);
        }

        return total;
	}
}
