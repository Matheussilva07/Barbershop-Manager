using BarbershopManager.Domain.Entities;

namespace BarbershopManager.Domain.Services;
public interface ILoggedUser
{
	Task<User> GetUser();	
}
