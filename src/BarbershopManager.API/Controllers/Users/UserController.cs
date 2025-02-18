using BarbershopManager.Application.UseCases.Users.GetProfile;
using BarbershopManager.Application.UseCases.Users.Register;
using BarbershopManager.Communication.Requests.Users;
using BarbershopManager.Communication.Responses.Users;
using Microsoft.AspNetCore.Mvc;

namespace BarbershopManager.API.Controllers.Users;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
	[HttpPost]
	[ProducesResponseType(typeof(ResponseRegisteredUserJson),StatusCodes.Status201Created)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> Register([FromServices]IRegisterUserUseCase useCase,[FromBody]RequestRegisterUserJson request)
	{
		var response = await useCase.Execute(request);

		return Created(string.Empty, response);
	}

	[HttpGet]
	[ProducesResponseType(typeof(ResponseUserJson), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> GetProfile([FromServices] IGetProfileUserUseCase useCase)
	{
		var response = await useCase.Execute();
		
		return Ok(response);
	}

}
