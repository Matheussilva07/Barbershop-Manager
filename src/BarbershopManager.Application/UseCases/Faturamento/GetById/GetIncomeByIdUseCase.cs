using AutoMapper;
using BarbershopManager.Communication.Responses;
using BarbershopManager.Domain.IncomeRepository;
using BarbershopManager.Exception.ExceptionBase;

namespace BarbershopManager.Application.UseCases.Faturamento.GetById;
public class GetIncomeByIdUseCase : IGetIncomeByIdUseCase
{
    private readonly IMapper _mapper;
    private readonly IIncomesRepository _repository;
    public GetIncomeByIdUseCase(IMapper mapper, IIncomesRepository repository)
    {
        this._mapper = mapper;
        this._repository = repository;
    }
    public async Task<ResponseIncomeJson> Execute(int id)
	{
		var income = await _repository.GetById(id);

        if (income is null)
        {
            throw new NotFoundException(ResourceErrorMessages.NAO_ENCONTRADO);
        }

        return _mapper.Map<ResponseIncomeJson>(income);
        	
	}
}
