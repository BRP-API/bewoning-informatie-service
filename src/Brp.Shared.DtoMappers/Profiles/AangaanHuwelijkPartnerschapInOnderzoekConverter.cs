using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;

namespace Brp.Shared.DtoMappers.Profiles;

public class AangaanHuwelijkPartnerschapInOnderzoekConverter : ITypeConverter<BrpDtos.InOnderzoek, BrpApiDtos.AangaanHuwelijkPartnerschapInOnderzoek?>
{
    public BrpApiDtos.AangaanHuwelijkPartnerschapInOnderzoek? Convert(BrpDtos.InOnderzoek source, BrpApiDtos.AangaanHuwelijkPartnerschapInOnderzoek? destination, ResolutionContext context)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "050000" or
            "050600" => new BrpApiDtos.AangaanHuwelijkPartnerschapInOnderzoek
            {
                Datum = true,
                Land = true,
                Plaats = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "050610" => new BrpApiDtos.AangaanHuwelijkPartnerschapInOnderzoek
            {
                Datum = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "050620" => new BrpApiDtos.AangaanHuwelijkPartnerschapInOnderzoek
            {
                Plaats = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "050630" => new BrpApiDtos.AangaanHuwelijkPartnerschapInOnderzoek
            {
                Land = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            _ => null,
        };
    }
}