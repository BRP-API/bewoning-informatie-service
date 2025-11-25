using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;

namespace Brp.Shared.DtoMappers.Profiles;

public class OuderInOnderzoekConverter : ITypeConverter<BrpDtos.InOnderzoek, BrpApiDtos.OuderInOnderzoek?>
{
    public BrpApiDtos.OuderInOnderzoek? Convert(BrpDtos.InOnderzoek source, BrpApiDtos.OuderInOnderzoek? destination, ResolutionContext context)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "020000" or
            "030000" => new BrpApiDtos.OuderInOnderzoek
            {
                Burgerservicenummer = true,
                Geslacht = true,
                DatumIngangFamilierechtelijkeBetrekking = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "020100" or
            "020120" or
            "030100" or
            "030120" => new BrpApiDtos.OuderInOnderzoek
            {
                Burgerservicenummer = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "020400" or
            "020410" or
            "030400" or
            "030410" => new BrpApiDtos.OuderInOnderzoek
            {
                Geslacht = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "026200" or
            "026210" or
            "036200" or
            "036210" => new BrpApiDtos.OuderInOnderzoek
            {
                DatumIngangFamilierechtelijkeBetrekking = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            _ => null,
        };
    }
}
