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
        _dbcontext = dbContext;
    }

    public async Task Add(Income income)
	{
		await _dbcontext.Incomes.AddAsync(income);
	}
	public async Task<List<Income>> GetAll(User user)
	{
		return await _dbcontext.Incomes.AsNoTracking().Where(income => income.UserId == user.Id).ToListAsync();
	}
    async Task<Income?> IIncomesRepository.GetById(int id, User user)
	{
		return await _dbcontext.Incomes.AsNoTracking().FirstOrDefaultAsync(income => income.Id == id && income.UserId == user.Id);
	}
	async Task<Income?> IUpdateRepository.GetById(int id, User user)
	{
		return await _dbcontext.Incomes.FirstOrDefaultAsync(income => income.Id == id && income.UserId == user.Id);
	}
	public void Update(Income income)
	{
		_dbcontext.Incomes.Update(income);
	}
	public async Task<bool> Delete(int id, User user)
	{
		var income =await _dbcontext.Incomes.FirstOrDefaultAsync(income => income.Id == id && income.UserId == user.Id);

		if (income is null)
		{
			return false;
		}
			_dbcontext.Incomes.Remove(income);

			return true;
	}
	public async Task<int> CountAll(User user)
	{
		return await _dbcontext.Incomes.Where(income => income.UserId == user.Id).CountAsync();
	}
	public async Task<int> CountAllInMonth(DateOnly date, User user)
	{
		var inicialDate = new DateTime(year: date.Year, month: date.Month, day: 1).Date;

		var daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);

		var finalDate = new DateTime(year: date.Year, month: date.Month, day: daysInMonth, hour:23, minute: 59, second: 59);

		return await _dbcontext.Incomes
			.AsNoTracking()
			.Where(income => income.Data_Servico > inicialDate && income.Data_Servico < finalDate && income.UserId == user.Id)
			.OrderBy(income => income.Data_Servico).CountAsync();
	}
}
