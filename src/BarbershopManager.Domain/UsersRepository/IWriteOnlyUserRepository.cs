using BarbershopManager.Domain.Entities;

namespace BarbershopManager.Domain.UsersRepository;
public interface IWriteOnlyUserRepository
{
	Task Add(User user);
}
