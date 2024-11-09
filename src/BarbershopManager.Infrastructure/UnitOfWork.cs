using BarbershopManager.Domain;
using BarbershopManager.Infrastructure.DataAccess;

namespace BarbershopManager.Infrastructure;
internal class UnitOfWork : IUnitOfWork
{
    private readonly BarbershopDbContext _context;
	public UnitOfWork(BarbershopDbContext dbContext)
    {
        this._context = dbContext;
    }
    public async Task Commit()
	{
		await _context.SaveChangesAsync();
	}
}
