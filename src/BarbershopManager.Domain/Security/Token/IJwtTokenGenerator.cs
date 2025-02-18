using BarbershopManager.Domain.Entities;

namespace BarbershopManager.Domain.Security.Token;
public interface IJwtTokenGenerator
{
	string GenerateToken(User user);
}
