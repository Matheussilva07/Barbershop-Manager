using AutoMapper;
using BarbershopManager.Communication.Requests.Incomes;
using BarbershopManager.Domain;
using BarbershopManager.Domain.IncomeRepository;
using BarbershopManager.Domain.Services;
using BarbershopManager.Exception.ExceptionBase;

namespace BarbershopManager.Application.UseCases.Faturamento.Update;
public class UpdateIncomeUseCase : IUpdateIncomeUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUpdateRepository _repository;
    private readonly ILoggedUser _loggedUser;
	public UpdateIncomeUseCase(IMapper mapper, IUnitOfWork unitOfWork, IUpdateRepository repository, ILoggedUser loggedUser)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
		_repository = repository;
		_loggedUser = loggedUser;
	}
	public async Task Execute(int id, RequestUpdateIncomeJson request)
	{
        var loggedUser = await _loggedUser.GetUser();

		var income = await _repository.GetById(id, loggedUser) ?? throw new NotFoundException(ResourceErrorMessages.NAO_ENCONTRADO);

        _mapper.Map(request, income);

        _repository.Update(income);

        await _unitOfWork.Commit();
	}
}
