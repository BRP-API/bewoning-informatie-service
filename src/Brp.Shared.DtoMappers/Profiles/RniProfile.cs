using AutoMapper;

namespace Brp.Shared.DtoMappers.Profiles;

public class RniProfile : Profile
{
	public RniProfile()
	{
		CreateMap<CommonDtos.RniDeelnemer, CommonDtos.RniDeelnemer>();
	}
}
