using BarbershopManager.Communication.Requests;
using BarbershopManager.Communication.Responses.Users;

namespace BarbershopManager.Application.UseCases.Users.Login;
public interface IDoLoginUseCase
{
	Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request);
}
