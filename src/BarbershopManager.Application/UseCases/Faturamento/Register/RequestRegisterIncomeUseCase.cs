using AutoMapper;
using BarbershopManager.Communication.Requests.Incomes;
using BarbershopManager.Communication.Responses;
using BarbershopManager.Domain;
using BarbershopManager.Domain.Entities;
using BarbershopManager.Domain.IncomeRepository;
using BarbershopManager.Domain.Services;
using BarbershopManager.Exception.ExceptionBase;

namespace BarbershopManager.Application.UseCases.Faturamento.Register;
public class RequestRegisterIncomeUseCase : IRequestRegisterIncomeUseCase
{
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _unitOfWork;
	private readonly IIncomesRepository _repository;
	private readonly ILoggedUser _loggedUser;

	public RequestRegisterIncomeUseCase(IMapper mapper, IUnitOfWork unitOfWork, IIncomesRepository repository, ILoggedUser loggedUser)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
		_repository = repository;
		_loggedUser = loggedUser;
	}
	public async Task<ResponseRegisteredIncomeJson> Execute(RequestRegisterIncomeJson request)
	{
		Validator(request);

		var loggedUser = await _loggedUser.GetUser();

		var entity = _mapper.Map<Income>(request);
		entity.UserId = loggedUser.Id;

		await _repository.Add(entity);

		await _unitOfWork.Commit();

		return _mapper.Map<ResponseRegisteredIncomeJson>(entity);

	}

	private void Validator(RequestRegisterIncomeJson request)
	{
		var validator = new RequestRegisterIncomeValidator();

		var result = validator.Validate(request);

		if (result.IsValid == false)
		{
			var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
					
			throw new ErrorOnValidationException(errorMessages);
		}
	}
}
