using BarbershopManager.Domain.Security.Cryptography;
using BC = BCrypt.Net.BCrypt;

namespace BarbershopManager.Infrastructure.Security.Cryptography;
internal class Encryptor : IEncryptor
{
	string IEncryptor.Encrypte(string password)
    {
        string passwordHash = BC.HashPassword(password);

        return passwordHash;
    }
	public bool PasswordMatch(string password, string passwordHash)
	{
		return BC.Verify(password, passwordHash);
	}

}
