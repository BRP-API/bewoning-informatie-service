using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;

namespace Brp.Shared.DtoMappers.Profiles;

public class NationaliteitOnbekendInOnderzoekConverter : ITypeConverter<BrpDtos.InOnderzoek, BrpApiDtos.NationaliteitOnbekendInOnderzoek?>
{
    public BrpApiDtos.NationaliteitOnbekendInOnderzoek? Convert(BrpDtos.InOnderzoek source, BrpApiDtos.NationaliteitOnbekendInOnderzoek? destination, ResolutionContext context)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "040000" => new BrpApiDtos.NationaliteitOnbekendInOnderzoek
            {
                RedenOpname = true,
                Type = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "040500" or "040510" => new BrpApiDtos.NationaliteitOnbekendInOnderzoek
            {
                Type = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "046300" or "046310" => new BrpApiDtos.NationaliteitOnbekendInOnderzoek
            {
                RedenOpname = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            _ => null
        };
    }
}
