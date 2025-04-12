using BarbershopManager.Communication.Requests.Users;
using Bogus;

namespace CommomUtilities.RequestsBuilder;
public class RequestRegisterUserBuilder
{
	public static RequestRegisterUserJson Build()
	{
		return new Faker<RequestRegisterUserJson>()
			.RuleFor(user => user.Name, faker => faker.Person.FullName)
			.RuleFor(user => user.Email, (faker, user) => faker.Internet.Email(user.Name))
			.RuleFor(user => user.Password, faker => faker.Internet.Password(prefix:"aX1!"));
	}
}
