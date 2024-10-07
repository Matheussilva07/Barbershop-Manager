using AutoMapper;
using BarbershopManager.Communication.Requests;
using BarbershopManager.Communication.Responses;
using BarbershopManager.Domain.Entities;

namespace BarbershopManager.Application.AutoMapper;
public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }
    private void RequestToEntity()
    {
        CreateMap<RequestRegisterIncomeJson, Income>();
        CreateMap<RequestUpdateIncomeJson, Income>();
    }
    private void EntityToResponse()
    {
        CreateMap<Income, ResponseRegisteredIncomeJson>();
        CreateMap<Income, ResponseShortIncomesJson>();
        CreateMap<Income, ResponseIncomeJson>();
		
	}

}
