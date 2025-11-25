using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;

namespace Brp.Shared.DtoMappers.Profiles;

public class OpschortingBijhoudingProfile : Profile
{
    public OpschortingBijhoudingProfile()
    {
        CreateMap<BrpDtos.OpschortingBijhoudingBasis, BrpApiDtos.OpschortingBijhoudingBasis>();

        CreateMap<BrpDtos.GbaOpschortingBijhouding, BrpApiDtos.OpschortingBijhouding>()
            .ForMember(dest => dest.Datum, opt => opt.MapFrom(src => src.Datum.Map()));
    }
}
