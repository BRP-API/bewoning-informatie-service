using AutoMapper;

namespace Brp.Shared.DtoMappers.Profiles;

public class AdellijkeTitelPredicaatTypeProfile : Profile
{
    public AdellijkeTitelPredicaatTypeProfile()
    {
        CreateMap<CommonDtos.AdellijkeTitelPredicaatType, CommonDtos.AdellijkeTitelPredicaatType>()
            .ForMember(dest => dest.Soort, opt => opt.MapFrom(src => src.Soort))
            ;
    }
}
