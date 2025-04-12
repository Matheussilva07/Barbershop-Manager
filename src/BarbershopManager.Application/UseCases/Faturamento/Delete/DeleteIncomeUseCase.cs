using BarbershopManager.Domain;
using BarbershopManager.Domain.IncomeRepository;
using BarbershopManager.Domain.Services;
using BarbershopManager.Exception.ExceptionBase;

namespace BarbershopManager.Application.UseCases.Faturamento.Delete;
public class DeleteIncomeUseCase : IDeleteIncomeUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IIncomesRepository _repository;
    private readonly ILoggedUser _loggedUser;
	public DeleteIncomeUseCase(IUnitOfWork unitOfWork, IIncomesRepository repository, ILoggedUser loggedUser)
	{
		this._unitOfWork = unitOfWork;
		this._repository = repository;
		_loggedUser = loggedUser;
	}

	public async Task Execute(int id)
	{
		var loggedUser = await _loggedUser.GetUser();

		var result = await _repository.Delete(id, loggedUser);

        if (result == false)
        {
            throw new NotFoundException(ResourceErrorMessages.NAO_ENCONTRADO);
        }

        await _unitOfWork.Commit();
	}
}
