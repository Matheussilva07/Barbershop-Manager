using BarbershopManager.Domain.Services;

namespace BarbershopManager.API.Token;

public class HttpContextAccessorRequest : ITokenProvider
{
	private readonly IHttpContextAccessor _contextAccessor;

	public HttpContextAccessorRequest(IHttpContextAccessor contextAccessor)
	{
		_contextAccessor = contextAccessor;
	}

	public string GetToken()
	{
		string token = _contextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

		return token["Bearer ".Length..];
	}
}
