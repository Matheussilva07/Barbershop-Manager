using BarbershopManager.Domain;
using BarbershopManager.Domain.IncomeRepository;

namespace BarbershopManager.Application.UseCases.Faturamento.Delete;
public class DeleteIncomeUseCase : IDeleteIncomeUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IIncomesRepository _repository;
    public DeleteIncomeUseCase(IUnitOfWork unitOfWork, IIncomesRepository repository)
    {
        this._unitOfWork = unitOfWork;
        this._repository = repository;
    }

	public async Task Execute(int id)
	{
		var result = await _repository.Delete(id);

        if (result == false)
        {
            throw new Exception("Income not found");
        }

        await _unitOfWork.Commit();
	}
}
