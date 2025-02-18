using AutoMapper;
using BarbershopManager.Communication.Requests.Incomes;
using BarbershopManager.Communication.Requests.Users;
using BarbershopManager.Communication.Responses;
using BarbershopManager.Communication.Responses.Users;
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


        CreateMap<RequestRegisterUserJson, User>().ForMember(user => user.Password, options => options.Ignore());
    }
    private void EntityToResponse()
    {
        CreateMap<Income, ResponseRegisteredIncomeJson>();
        CreateMap<Income, ResponseShortIncomesJson>();
        CreateMap<Income, ResponseIncomeJson>();

        CreateMap<User, ResponseRegisteredUserJson>();
        CreateMap<User, ResponseUserJson>();
		
	}

}
