namespace Brp.Shared.DtoMappers.Profiles;

public class OverlijdenProfile : DatumPlaatsLandDtoProfile<BrpDtos.GbaOverlijden, BrpApiDtos.Overlijden>
{
    public OverlijdenProfile()
    {
        CreateMap<BrpDtos.InOnderzoek, BrpApiDtos.OverlijdenInOnderzoek?>().ConvertUsing<OverlijdenInOnderzoekConverter>();
    }
}
