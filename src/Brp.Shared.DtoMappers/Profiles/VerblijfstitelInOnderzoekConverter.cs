using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;

namespace Brp.Shared.DtoMappers.Profiles;

public class VerblijfstitelInOnderzoekConverter : ITypeConverter<BrpDtos.InOnderzoek, BrpApiDtos.VerblijfstitelInOnderzoek?>
{
    public BrpApiDtos.VerblijfstitelInOnderzoek? Convert(BrpDtos.InOnderzoek source, BrpApiDtos.VerblijfstitelInOnderzoek? destination, ResolutionContext context)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "100000" or "103900" => new BrpApiDtos.VerblijfstitelInOnderzoek
            {
                Aanduiding= true,
                DatumIngang= true,
                DatumEinde= true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "103910" => new BrpApiDtos.VerblijfstitelInOnderzoek
            {
                Aanduiding= true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "103920" => new BrpApiDtos.VerblijfstitelInOnderzoek
            {
                DatumEinde= true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "103930" => new BrpApiDtos.VerblijfstitelInOnderzoek
            {
                DatumIngang = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            _ => null,
        };
    }
}
