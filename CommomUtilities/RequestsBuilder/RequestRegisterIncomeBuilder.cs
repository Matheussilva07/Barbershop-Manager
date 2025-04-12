using BarbershopManager.Communication.Enums;
using BarbershopManager.Communication.Requests.Incomes;
using Bogus;

namespace BarbershopManager.Tests;
public class RequestRegisterIncomeBuilder
{
	public static RequestRegisterIncomeJson Build()
	{
		var faker = new Faker();

		return new RequestRegisterIncomeJson
		{
			Nome = faker.Commerce.Product(),
			Data_Servico = faker.Date.Past(),
			Tipo_Servico = faker.PickRandom<Tipo_Servico>(),
			Preco = faker.Finance.Random.Decimal(min: 10, max: 1000),
			Tipo_Pagamento = faker.PickRandom<Tipo_Pagamento>()
		};
	}
}
