using AutoMapper;
using BarbershopManager.Communication.Responses;
using BarbershopManager.Domain.IncomeRepository;
using BarbershopManager.Domain.Services;

namespace BarbershopManager.Application.UseCases.Faturamento.GetAll;
public class GetAllIncomesUseCase : IGetAllIncomesUseCase
{
    private readonly IMapper _mapper;
    private readonly IIncomesRepository _repository;
    private readonly ILoggedUser _loggedUser;
	public GetAllIncomesUseCase(IMapper mapper, IIncomesRepository repository, ILoggedUser loggedUser)
	{
		this._mapper = mapper;
		this._repository = repository;
		_loggedUser = loggedUser;
	}

	public async Task<ResponsesIncomesListJson> Execute()
	{
		var loggedUser = await _loggedUser.GetUser();

		var incomes = await _repository.GetAll(loggedUser);

        return new ResponsesIncomesListJson
        {
            Incomes = _mapper.Map<List<ResponseShortIncomesJson>>(incomes)
        };
	}
}
