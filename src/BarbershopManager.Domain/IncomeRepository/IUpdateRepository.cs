using BarbershopManager.Domain.Entities;

namespace BarbershopManager.Domain.IncomeRepository;
public interface IUpdateRepository
{
	Task<Income?> GetById(int id);
	void Update(Income income);
}


