using BarbershopManager.Domain.Entities;

namespace BarbershopManager.Domain.IncomeRepository;
public interface IIncomesRepository
{
	Task Add(Income income);

	Task<List<Income>> GetAll(User user);

	Task<Income?> GetById(int id, User user);

	Task<bool> Delete(int id, User user);

	Task<int> CountAll(User user);      //Método para contar todos os registros

	Task<int> CountAllInMonth(DateOnly month, User user);
}
