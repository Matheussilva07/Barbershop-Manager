using BarbershopManager.Communication.Requests.Users;
using BarbershopManager.Communication.Responses.Users;

namespace BarbershopManager.Application.UseCases.Users.Register;
public interface IRegisterUserUseCase
{
	Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request);
}
