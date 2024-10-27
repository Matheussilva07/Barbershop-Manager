using BarbershopManager.Communication.Responses;
using BarbershopManager.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BarbershopManager.API.Filter;

public class ExceptionFilter : IExceptionFilter
{
	public void OnException(ExceptionContext context)
	{
		if(context.Exception is BarbershopException)
		{
			HandleProjectExpection(context);
		}
		else
		{
			ThrowUnknowError(context);
		}
	}

	private static void HandleProjectExpection(ExceptionContext context)
	{
		var barbershopException = (BarbershopException)context.Exception;
		var errorResponse = new ResponseErrorJson(barbershopException.GetErrors());

		context.HttpContext.Response.StatusCode = barbershopException.StatusCode;
		context.Result = new ObjectResult(errorResponse);
	}
	private static void ThrowUnknowError(ExceptionContext context)
	{
		var errorResponse = new ResponseErrorJson(ResourceErrorMessages.ERRO_DESCONHECIDO);

		context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
		context.Result = new ObjectResult(errorResponse);
	}
}
