namespace BarbershopManager.Domain;
public interface IUnitOfWork
{
	Task Commit();
}
