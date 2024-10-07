namespace BarbershopManager.Application.UseCases.Faturamento.CountByMonth;
public interface ICountByMonthUseCase
{
	Task<int> Execute(DateOnly month);
}
