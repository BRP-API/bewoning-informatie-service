using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;

namespace Brp.Shared.DtoMappers.Profiles;

public class OverlijdenInOnderzoekConverter : ITypeConverter<BrpDtos.InOnderzoek, BrpApiDtos.OverlijdenInOnderzoek?>
{
    public BrpApiDtos.OverlijdenInOnderzoek? Convert(BrpDtos.InOnderzoek source, BrpApiDtos.OverlijdenInOnderzoek? destination, ResolutionContext context)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "060000" or
            "060800" => new BrpApiDtos.OverlijdenInOnderzoek
            {
                Datum = true,
                Land = true,
                Plaats = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "060810" => new BrpApiDtos.OverlijdenInOnderzoek
            {
                Datum = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "060820" => new BrpApiDtos.OverlijdenInOnderzoek
            {
                Plaats = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "060830" => new BrpApiDtos.OverlijdenInOnderzoek
            {
                Land = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            _ => null,
        };
    }
}
