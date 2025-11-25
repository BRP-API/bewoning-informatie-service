using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;

namespace Brp.Shared.DtoMappers.Profiles;

public class PartnerInOnderzoekConverter : ITypeConverter<BrpDtos.InOnderzoek, BrpApiDtos.PartnerInOnderzoek?>
{
    public BrpApiDtos.PartnerInOnderzoek? Convert(BrpDtos.InOnderzoek source, BrpApiDtos.PartnerInOnderzoek? destination, ResolutionContext context)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "050000" => new BrpApiDtos.PartnerInOnderzoek
            {
                Burgerservicenummer = true,
                SoortVerbintenis = true,
                Geslacht = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "050100" or "050120" => new BrpApiDtos.PartnerInOnderzoek
            {
                Burgerservicenummer = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "050400" or "050410" => new BrpApiDtos.PartnerInOnderzoek
            {
                Geslacht = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "051500" or "051510" => new BrpApiDtos.PartnerInOnderzoek
            {
                SoortVerbintenis = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            _ => null,
        };
    }
}
