using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;

namespace Brp.Shared.DtoMappers.Profiles;

public class GeboorteBasisProfile : Profile
{
    public GeboorteBasisProfile()
    {
        CreateMap<BrpDtos.GeboorteBasis, BrpApiDtos.GeboorteBasis>()
            .ForMember(dest => dest.Datum, opt => opt.MapFrom(src => src.Datum.Map()))
            ;
    }
}
