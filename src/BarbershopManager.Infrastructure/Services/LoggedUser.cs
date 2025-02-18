using BarbershopManager.Domain.Entities;
using BarbershopManager.Domain.Services;
using BarbershopManager.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BarbershopManager.Infrastructure.Services;
internal class LoggedUser : ILoggedUser
{
	private readonly BarbershopDbContext _dbContext;
	private readonly ITokenProvider _tokenProvider;

	public LoggedUser(BarbershopDbContext dbContext, ITokenProvider tokenProvider)
	{
		_dbContext = dbContext;
		_tokenProvider = tokenProvider;
	}

	public async Task<User> GetUser()
	{
		var token = _tokenProvider.GetToken();

		var tokenHandler = new JwtSecurityTokenHandler();

		var jwtSecutityToken = tokenHandler.ReadJwtToken(token);

		var userIdentifier = jwtSecutityToken.Claims.First(claim => claim.Type == ClaimTypes.Sid).Value;

		return await _dbContext.Users.FirstAsync(user => user.UserIdentifier == Guid.Parse(userIdentifier));
	}
}
