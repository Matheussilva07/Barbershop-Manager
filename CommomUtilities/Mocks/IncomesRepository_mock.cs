using BarbershopManager.Domain.Entities;
using BarbershopManager.Domain.IncomeRepository;
using Moq;

namespace CommomUtilities.Mocks;
public class IncomesRepository_mock
{
	public static IIncomesRepository Build(Income income)
	{
		var mock = new Mock<IIncomesRepository>();

		mock.Setup(repository => repository.Add(income));

		return mock.Object;	
	}
}
