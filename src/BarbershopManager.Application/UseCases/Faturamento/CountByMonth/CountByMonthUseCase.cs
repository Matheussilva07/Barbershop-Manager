
using BarbershopManager.Domain.IncomeRepository;
using BarbershopManager.Exception.ExceptionBase;

namespace BarbershopManager.Application.UseCases.Faturamento.CountByMonth;
public class CountByMonthUseCase : ICountByMonthUseCase
{
    private readonly IIncomesRepository _repository;
    public CountByMonthUseCase(IIncomesRepository repository)
    {
        this._repository = repository;
    }
    public async Task<int> Execute(DateOnly month)
	{
        var total = await _repository.CountAllInMonth(month);

        if (total == 0)
        {
            throw new NotFoundException(ResourceErrorMessages.NAO_ENCONTRADO);
        }

        return total;
	}
}
