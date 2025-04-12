using BarbershopManager.Domain.Entities;
using Bogus;

namespace CommomUtilities.EntitiesBuilder;
public class IncomeBuilder
{
	public static Income GetIncome()
	{
		return new Faker<Income>().RuleFor(income => income.Id, 1)
			.RuleFor(income => income.Nome, faker => faker.Commerce.Product())
			.RuleFor(income => income.Data_Servico, faker => faker.Date.Past())
			.RuleFor(income => income.Tipo_Servico, BarbershopManager.Domain.Enums.Tipo_Servico.corte_moicano)
			.RuleFor(income => income.Preco, faker => faker.Random.Decimal(10, 200))
			.RuleFor(income => income.Tipo_Pagamento, BarbershopManager.Domain.Enums.Tipo_Pagamento.Cartao_debito)
			.RuleFor(income => income.UserId, 1);
	}
}
