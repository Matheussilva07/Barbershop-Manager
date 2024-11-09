using BarbershopManager.Domain.Entities;
using BarbershopManager.Domain.IncomeRepository;
using BarbershopManager.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace BarbershopManager.Infrastructure.IncomeRepository;
internal class IncomesRepository : IIncomesRepository, IUpdateRepository
{
	private readonly BarbershopDbContext _dbcontext;
	public IncomesRepository(BarbershopDbContext dbContext)
    {
        this._dbcontext = dbContext;
    }

    public async Task Add(Income income)
	{
		await _dbcontext.Incomes.AddAsync(income);
	}
	public async Task<List<Income>> GetAll()
	{
		return await _dbcontext.Incomes.AsNoTracking().ToListAsync();
	}
    async Task<Income?> IIncomesRepository.GetById(int id)
	{
		return await _dbcontext.Incomes.AsNoTracking().FirstOrDefaultAsync(income => income.Id == id);
	}
	async Task<Income?> IUpdateRepository.GetById(int id)
	{
		return await _dbcontext.Incomes.FirstOrDefaultAsync(income => income.Id == id);
	}
	public void Update(Income income)
	{
		_dbcontext.Incomes.Update(income);
	}
	public async Task<bool> Delete(int id)
	{
		var income =await _dbcontext.Incomes.FirstOrDefaultAsync(income => income.Id == id);

		if (income is null)
		{
			return false;
		}

			_dbcontext.Incomes.Remove(income);

			return true;
		

	}
	public async Task<int> CountAll()
	{
		return await _dbcontext.Incomes.CountAsync();
	}
	public async Task<int> CountAllInMonth(DateOnly date)
	{
		var inicialDate = new DateTime(year: date.Year, month: date.Month, day: 1).Date;

		var daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);

		var finalDate = new DateTime(year: date.Year, month: date.Month, day: daysInMonth, hour:23, minute: 59, second: 59);

		return await _dbcontext.Incomes
			.AsNoTracking()
			.Where(income => income.Data_Servico > inicialDate && income.Data_Servico < finalDate)
			.OrderBy(income => income.Data_Servico).CountAsync();
	}
}
