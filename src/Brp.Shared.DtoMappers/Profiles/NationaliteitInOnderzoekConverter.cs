using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;

namespace Brp.Shared.DtoMappers.Profiles;

public class NationaliteitInOnderzoekConverter : ITypeConverter<BrpDtos.InOnderzoek, BrpApiDtos.NationaliteitBekendInOnderzoek?>
{
    public BrpApiDtos.NationaliteitBekendInOnderzoek? Convert(BrpDtos.InOnderzoek source, BrpApiDtos.NationaliteitBekendInOnderzoek? destination, ResolutionContext context)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "040000" => new BrpApiDtos.NationaliteitBekendInOnderzoek
            {
                Nationaliteit = true,
                RedenOpname = true,
                Type = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "040500" or "040510" => new BrpApiDtos.NationaliteitBekendInOnderzoek
            {
                Nationaliteit = true,
                Type = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()

            },
            "046300" or "046310" => new BrpApiDtos.NationaliteitBekendInOnderzoek
            {
                RedenOpname = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()

            },
            _ => null
        };
    }
}
