using AutoMapper;
using BarbershopManager.Communication.Responses;
using BarbershopManager.Domain.IncomeRepository;

namespace BarbershopManager.Application.UseCases.Faturamento.GetAll;
public class GetAllIncomesUseCase : IGetAllIncomesUseCase
{
    private readonly IMapper _mapper;
    private readonly IIncomesRepository _repository;
    public GetAllIncomesUseCase(IMapper mapper, IIncomesRepository repository)
    {
        this._mapper = mapper;
        this._repository = repository;
    }

	public async Task<ResponsesIncomesListJson> Execute()
	{
        var incomes = await _repository.GetAll();

        return new ResponsesIncomesListJson
        {
            Incomes = _mapper.Map<List<ResponseShortIncomesJson>>(incomes)
        };
	}
}
