using BarbershopManager.Application.UseCases.Faturamento.CountAll;
using BarbershopManager.Application.UseCases.Faturamento.CountByMonth;
using BarbershopManager.Application.UseCases.Faturamento.Delete;
using BarbershopManager.Application.UseCases.Faturamento.GetAll;
using BarbershopManager.Application.UseCases.Faturamento.GetById;
using BarbershopManager.Application.UseCases.Faturamento.Register;
using BarbershopManager.Application.UseCases.Faturamento.Update;
using BarbershopManager.Communication.Requests;
using BarbershopManager.Communication.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarbershopManager.API.Controllers.faturamento;
[Route("api/[controller]")]
[ApiController]
public class IncomeController : ControllerBase
{
	[HttpPost]
	[ProducesResponseType(typeof(ResponseRegisteredIncomeJson),StatusCodes.Status201Created)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> Register([FromServices] IRequestRegisterIncomeUseCase useCase,[FromBody] RequestRegisterIncomeJson request )
	{
		var response = await useCase.Execute(request);

		return Created(string.Empty, response);
	}

	[HttpGet]
	[ProducesResponseType(typeof(ResponsesIncomesListJson),StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	public async Task<IActionResult> GetAll([FromServices]IGetAllIncomesUseCase useCase)
	{
		var incomes = await useCase.Execute();

		if (incomes.Incomes.Count > 0)
		{
			return Ok(incomes);
		}

		return NoContent();
	}

	[HttpGet]
	[Route("{id}")]
	[ProducesResponseType(typeof(ResponseIncomeJson),StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> GetById([FromServices]IGetIncomeByIdUseCase useCase, [FromRoute]int id)
	{
		var income = await useCase.Execute(id);

		return Ok(income);
	}

	[HttpPut]
	[Route("{id}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> Update([FromServices]IUpdateIncomeUseCase useCase, [FromRoute]int id,[FromBody] RequestUpdateIncomeJson request)
	{
		await useCase.Execute(id, request);
		
		return NoContent();
	}

	[HttpDelete]
	[Route("{id}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> Delete([FromServices]IDeleteIncomeUseCase useCase, [FromRoute] int id)
	{
		await useCase.Execute(id);

		return NoContent();
	}

	[HttpGet("total-incomes")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	public async Task<IActionResult> CountAll([FromServices]ICountAllIncomesUseCase useCase)
	{
		var total = await useCase.Execute();

		return Ok($"{total} despesas");
	}
	[HttpGet("total-incomes-inMonth")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	public async Task<IActionResult> CountAllByMonth([FromServices] ICountByMonthUseCase useCase,[FromHeader] DateOnly month)
	{
		var total = await useCase.Execute(month);

		return Ok($"{total} despesas");
	}
}
