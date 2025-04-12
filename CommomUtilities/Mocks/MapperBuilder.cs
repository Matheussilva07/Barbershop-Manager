using AutoMapper;
using BarbershopManager.Application.AutoMapper;

namespace CommomUtilities.Mocks;
public class MapperBuilder
{
	public static IMapper Build()
	{
		var mapper = new MapperConfiguration(config =>
		{
			config.AddProfile(new AutoMapping());
		});

		return mapper.CreateMapper();
	}
}