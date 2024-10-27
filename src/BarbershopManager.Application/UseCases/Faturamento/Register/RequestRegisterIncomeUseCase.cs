using AutoMapper;
using BarbershopManager.Communication.Requests;
using BarbershopManager.Communication.Responses;
using BarbershopManager.Domain;
using BarbershopManager.Domain.Entities;
using BarbershopManager.Domain.IncomeRepository;
using BarbershopManager.Exception.ExceptionBase;

namespace BarbershopManager.Application.UseCases.Faturamento.Register;
public class RequestRegisterIncomeUseCase : IRequestRegisterIncomeUseCase
{
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _unitOfWork;
	private readonly IIncomesRepository _repository;

    public RequestRegisterIncomeUseCase(IMapper mapper, IUnitOfWork unitOfWork, IIncomesRepository repository)
    {
        this._mapper = mapper;
		this._unitOfWork = unitOfWork;
		this._repository = repository;
    }
    public async Task<ResponseRegisteredIncomeJson> Execute(RequestRegisterIncomeJson request)
	{
		Validator(request);

		var entity = _mapper.Map<Income>(request);

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
