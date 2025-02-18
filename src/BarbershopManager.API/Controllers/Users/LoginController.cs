using BarbershopManager.Application.UseCases.Users.Login;
using BarbershopManager.Communication.Requests;
using BarbershopManager.Communication.Responses.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarbershopManager.API.Controllers.Users;
[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{

	[HttpPost]
	[ProducesResponseType(typeof(ResponseRegisteredUserJson),StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status401Unauthorized)]
	public async Task<IActionResult> Login([FromServices]IDoLoginUseCase useCase ,[FromBody]RequestLoginJson request)
	{
		var response = await useCase.Execute(request);

		return Ok(response);

	}

}
