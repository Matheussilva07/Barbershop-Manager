using BarbershopManager.Domain.Entities;
using BarbershopManager.Domain.UsersRepository;
using BarbershopManager.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace BarbershopManager.Infrastructure.UsersRepository;
internal class UserRepository : IWriteOnlyUserRepository, IReadOnlyUserRepository
{
    private readonly BarbershopDbContext _dbcontext;
    public UserRepository(BarbershopDbContext dbContext)
    {
        _dbcontext = dbContext;
    }
    public async Task Add(User user)
	{
		await _dbcontext.Users.AddAsync(user);
	}

	public async Task<bool> ExistAnyUserWithThisEmail(string email)
	{
		return await _dbcontext.Users.AnyAsync(user => user.Email == email);		
	}
}
