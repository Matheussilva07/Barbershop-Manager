using BarbershopManager.Domain.Entities;

namespace BarbershopManager.Domain.UsersRepository;
public interface IReadOnlyUserRepository
{
	Task<bool> ExistAnyUserWithThisEmail(string email);
	Task<User?> GetUserByEmail(string email);	
	Task<User> GetProfileLoggedUser(Guid UserIdentifier);
}
