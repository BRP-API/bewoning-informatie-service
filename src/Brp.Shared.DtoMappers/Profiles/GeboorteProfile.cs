using Brp.Shared.DtoMappers.Mappers;

namespace Brp.Shared.DtoMappers.Profiles;

public class GeboorteProfile : DatumPlaatsLandDtoProfile<BrpDtos.GbaGeboorte, BrpApiDtos.Geboorte>
{
    public GeboorteProfile()
    {
        CreateMap<BrpDtos.GeboorteBasis, BrpApiDtos.GeboorteBeperkt>()
            .ForMember(dest => dest.Datum, opt => opt.MapFrom(src => src.Datum.Map()))
            ;
    }
}
