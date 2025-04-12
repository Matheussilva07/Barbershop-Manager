using AutoMapper;
using BarbershopManager.Communication.Responses;
using BarbershopManager.Domain.IncomeRepository;
using BarbershopManager.Domain.Services;
using BarbershopManager.Exception.ExceptionBase;

namespace BarbershopManager.Application.UseCases.Faturamento.GetById;
public class GetIncomeByIdUseCase : IGetIncomeByIdUseCase
{
    private readonly IMapper _mapper;
    private readonly IIncomesRepository _repository;
    private readonly ILoggedUser _loggedUser;
	public GetIncomeByIdUseCase(IMapper mapper, IIncomesRepository repository, ILoggedUser loggedUser)
	{
		_mapper = mapper;
		_repository = repository;
		_loggedUser = loggedUser;
	}
	public async Task<ResponseIncomeJson> Execute(int id)
	{
		var loggedUser = await _loggedUser.GetUser();

		var income = await _repository.GetById(id, loggedUser) ?? throw new NotFoundException(ResourceErrorMessages.NAO_ENCONTRADO);

        return _mapper.Map<ResponseIncomeJson>(income);
        	
	}
}
