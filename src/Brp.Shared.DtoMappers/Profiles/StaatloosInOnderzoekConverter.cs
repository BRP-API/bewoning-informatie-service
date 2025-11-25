using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;

namespace Brp.Shared.DtoMappers.Profiles;

public class StaatloosInOnderzoekConverter : ITypeConverter<BrpDtos.InOnderzoek, BrpApiDtos.StaatloosInOnderzoek?>
{
    public BrpApiDtos.StaatloosInOnderzoek? Convert(BrpDtos.InOnderzoek source, BrpApiDtos.StaatloosInOnderzoek? destination, ResolutionContext context)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "040000" => new BrpApiDtos.StaatloosInOnderzoek
            {
                RedenOpname = true,
                Type = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "040500" or
            "040510" or
            "046500" or
            "046510" => new BrpApiDtos.StaatloosInOnderzoek
            {
                Type = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()

            },
            "046300" or "046310" => new BrpApiDtos.StaatloosInOnderzoek
            {
                RedenOpname = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()

            },
            _ => null
        };
    }
}
