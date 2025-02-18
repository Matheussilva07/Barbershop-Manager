using BarbershopManager.Communication.Requests;
using BarbershopManager.Communication.Responses.Users;
using BarbershopManager.Domain.Security.Cryptography;
using BarbershopManager.Domain.Security.Token;
using BarbershopManager.Domain.UsersRepository;
using System.Text.RegularExpressions;

namespace BarbershopManager.Application.UseCases.Users.Login;
public class DoLoginUseCase : IDoLoginUseCase
{
    private readonly IEncryptor _encryptor;
    private readonly IReadOnlyUserRepository _repository;
    private readonly IJwtTokenGenerator _tokenGenerator;

	public DoLoginUseCase(IEncryptor encryptor, IReadOnlyUserRepository repository, IJwtTokenGenerator tokenGenerator)
    {
        _encryptor = encryptor;
        _repository = repository;
        _tokenGenerator = tokenGenerator;
    }
    public async Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request)
	{
		EmailValidator(request);

        var user = await _repository.GetUserByEmail(request.Email);

        if (user is null)
        {
            throw new System.Exception("Usuário inexistente");
        }

        var passwordMatch = _encryptor.PasswordMatch(request.Password, user.Password);

        if (passwordMatch == false)
        {
            throw new System.Exception("Senha inválida!");
        }

        return new ResponseRegisteredUserJson
        {
            Name = user.Name,
            Token = _tokenGenerator.GenerateToken(user)
        };
	}
    private void EmailValidator(RequestLoginJson request)
    {
        if (string.IsNullOrWhiteSpace(request.Email))
        {
            throw new System.Exception("Digite o email!");
        }
        if (Regex.IsMatch(request.Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$") == false)
        {
			throw new System.Exception("Digite um email válido!");
		}
    }
}
