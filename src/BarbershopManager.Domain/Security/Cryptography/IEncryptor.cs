namespace BarbershopManager.Domain.Security.Cryptography;
public interface IEncryptor
{
    string Encrypte(string password);
    bool PasswordMatch(string password, string passwordHash);
}
