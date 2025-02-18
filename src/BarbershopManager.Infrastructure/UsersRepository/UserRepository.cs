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
		return await _dbcontext.Users.AnyAsync(user => user.Email.Equals(email));
	}

	public async Task<User> GetProfileLoggedUser(Guid UserIdentifier)
	{
		return await _dbcontext.Users.AsNoTracking().FirstAsync(user => user.UserIdentifier == UserIdentifier);
	}

	public async Task<User?> GetUserByEmail(string email)
	{
		return await _dbcontext.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Email.Equals(email));
	}
}
