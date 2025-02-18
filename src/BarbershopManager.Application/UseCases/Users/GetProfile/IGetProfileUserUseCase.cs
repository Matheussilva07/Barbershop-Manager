using BarbershopManager.Communication.Responses.Users;

namespace BarbershopManager.Application.UseCases.Users.GetProfile;
public interface IGetProfileUserUseCase
{
	Task<ResponseUserJson> Execute();
}
