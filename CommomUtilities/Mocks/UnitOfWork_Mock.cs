using BarbershopManager.Domain;
using Moq;

namespace CommomUtilities.Mocks;
public class UnitOfWork_Mock
{
	public static IUnitOfWork Build()
	{
		var mock = new Mock<IUnitOfWork>();

		return mock.Object;
	}
}
