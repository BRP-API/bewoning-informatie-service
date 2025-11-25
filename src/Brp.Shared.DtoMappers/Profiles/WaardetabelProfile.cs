using AutoMapper;

namespace Brp.Shared.DtoMappers.Profiles;

public class WaardetabelProfile : Profile
{
    public WaardetabelProfile()
    {
        CreateMap<CommonDtos.Waardetabel, CommonDtos.Waardetabel>();
    }
}
