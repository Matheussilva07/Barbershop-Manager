using BarbershopManager.Domain.Entities;

namespace BarbershopManager.Domain.UsersRepository;
public interface IReadOnlyUserRepository
{
	Task<bool> ExistAnyUserWithThisEmail(string email);
}
