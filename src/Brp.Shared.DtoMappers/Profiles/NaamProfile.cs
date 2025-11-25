using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;

namespace Brp.Shared.DtoMappers.Profiles;

public class NaamProfile : Profile
{
    public NaamProfile()
    {
        CreateMap<CommonDtos.NaamBasis, BrpApiDtos.NaamPersoonBeperkt>()
            .ForMember(dest => dest.Voorletters, opt => opt.MapFrom(src => src.Voorletters()))
            .ForMember(dest => dest.Geslachtsnaam, opt =>
            {
                opt.PreCondition(src => src.Geslachtsnaam != ".");
            })
            ;

        CreateMap<CommonDtos.NaamBasis, BrpApiDtos.NaamGerelateerde>()
            .ForMember(dest => dest.Voorletters, opt => opt.MapFrom(src => src.Voorletters()))
            .ForMember(dest => dest.Geslachtsnaam, opt =>
            {
                opt.PreCondition(src => src.Geslachtsnaam != ".");
                opt.MapFrom(src => src.Geslachtsnaam);
            })
            ;

        CreateMap<BrpDtos.GbaNaamPersoon, BrpApiDtos.NaamPersoon>()
            .ForMember(dest => dest.Geslachtsnaam, opt =>
            {
                opt.PreCondition(src => src.Geslachtsnaam != ".");
            })
            .ForMember(dest => dest.Voorletters, opt => opt.MapFrom(src => src.Voorletters()))
            ;
    }
}
