using BarbershopManager.Communication.Requests.Incomes;
using Bogus;

namespace BarbershopManager.Tests;
public class RequestRegisterIncomeBuilder
{
	public static RequestRegisterIncomeJson Builder()
	{
		var faker = new Faker();

		return new RequestRegisterIncomeJson()
		{
			Nome = faker.Name.ToString()!,
			Data_Servico = DateTime.UtcNow,
			Preco = 1550,
			Tipo_Pagamento = Communication.Enums.Tipo_Pagamento.Cartao_credito,
			Tipo_Servico = Communication.Enums.Tipo_Servico.corte_simples

		};
	}
}
