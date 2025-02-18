using AutoMapper;
using BarbershopManager.Communication.Responses.Users;
using BarbershopManager.Domain.Services;

namespace BarbershopManager.Application.UseCases.Users.GetProfile;
internal class GetProfileUserUseCase : IGetProfileUserUseCase
{
	private readonly IMapper _mapper;
	private readonly ILoggedUser _loggedUser;

	public GetProfileUserUseCase(IMapper mapper, ILoggedUser loggedUser)
	{
		_mapper = mapper;
		_loggedUser = loggedUser;
	}

	public async Task<ResponseUserJson> Execute()
	{
		var loggedUser = await _loggedUser.GetUser();

		return _mapper.Map<ResponseUserJson>(loggedUser);
	}
}
