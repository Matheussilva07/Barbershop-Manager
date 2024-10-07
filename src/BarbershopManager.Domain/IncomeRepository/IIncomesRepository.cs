using BarbershopManager.Domain.Entities;

namespace BarbershopManager.Domain.IncomeRepository;
public interface IIncomesRepository
{
	Task Add(Income income);
	Task<List<Income>> GetAll();
	Task<Income?> GetById(int id);
	Task<bool> Delete(int id);

	//Método para contar todos os registros
	Task<int> CountAll();	

	Task<int> CountAllInMonth(DateOnly month);
}
