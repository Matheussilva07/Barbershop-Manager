using BarbershopManager.Domain.Enums;

namespace BarbershopManager.Domain.Entities;
public class User
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;
	public string Password { get; set; } = string.Empty;
	public Guid UserIdentifier { get; set; }
	public string Token { get; set; } = string.Empty;
	public string Role { get; set; } = UserType.USER_NORMAL;
}
