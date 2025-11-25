namespace Brp.Shared.DtoMappers.Profiles;

public class AangaanHuwelijkPartnerschapProfile : DatumPlaatsLandDtoProfile<BrpDtos.GbaAangaanHuwelijkPartnerschap, BrpApiDtos.AangaanHuwelijkPartnerschap>
{
    public AangaanHuwelijkPartnerschapProfile()
    {
        CreateMap<BrpDtos.InOnderzoek, BrpApiDtos.AangaanHuwelijkPartnerschapInOnderzoek?>().ConvertUsing<AangaanHuwelijkPartnerschapInOnderzoekConverter>();
    }
}
