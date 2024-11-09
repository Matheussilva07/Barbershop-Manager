using BarbershopManager.Application.UseCases.Faturamento.CountByMonth;
using BarbershopManager.Communication.Responses.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarbershopManager.API.Controllers.Users;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
	[HttpPost]
	[ProducesResponseType(typeof(ResponseRegisteredUserJson),StatusCodes.Status201Created)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> Register()
	{
		var response = useCase.Execute();

		return Created(string.Empty, response);
	}
}
