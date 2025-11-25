using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;

namespace Brp.Shared.DtoMappers.Profiles;

public class EuropeesKiesrechtProfile : Profile
{
    public EuropeesKiesrechtProfile()
    {
        CreateMap<BrpDtos.GbaEuropeesKiesrecht, BrpApiDtos.EuropeesKiesrecht>()
            .ForMember(dest => dest.EinddatumUitsluiting, opt => opt.MapFrom(src => src.EinddatumUitsluiting.Map()));
    }
}
