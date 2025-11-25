using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;

namespace Brp.Shared.DtoMappers.Profiles;

public class UitsluitingKiesrechtProfile : Profile
{
    public UitsluitingKiesrechtProfile()
    {
        CreateMap<BrpDtos.GbaUitsluitingKiesrecht, BrpApiDtos.UitsluitingKiesrecht>()
            .ForMember(dest => dest.Einddatum, opt => opt.MapFrom(src => src.Einddatum.Map()));
    }
}
