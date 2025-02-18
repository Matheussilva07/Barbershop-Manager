using AutoMapper;
using BarbershopManager.Communication.Requests.Incomes;
using BarbershopManager.Domain;
using BarbershopManager.Domain.IncomeRepository;
using BarbershopManager.Exception.ExceptionBase;

namespace BarbershopManager.Application.UseCases.Faturamento.Update;
public class UpdateIncomeUseCase : IUpdateIncomeUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUpdateRepository _repository;
    public UpdateIncomeUseCase(IMapper mapper, IUnitOfWork unitOfWork, IUpdateRepository repository)
    {
        this._mapper = mapper;
        this._unitOfWork = unitOfWork;
        this._repository = repository;
    }
    public async Task Execute(int id, RequestUpdateIncomeJson request)
	{
        var income = await _repository.GetById(id);

        if (income is null)
        {
            throw new NotFoundException(ResourceErrorMessages.NAO_ENCONTRADO);
        }

        _mapper.Map(request, income);

        _repository.Update(income);

        await _unitOfWork.Commit();
	}
}
