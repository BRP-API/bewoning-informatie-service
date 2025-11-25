using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;

namespace Brp.Shared.DtoMappers.Profiles;

public class OntbondenPartnerInOnderzoekConverter : ITypeConverter<BrpDtos.InOnderzoek, BrpApiDtos.OntbindingHuwelijkPartnerschapInOnderzoek?>
{
    public BrpApiDtos.OntbindingHuwelijkPartnerschapInOnderzoek? Convert(BrpDtos.InOnderzoek source, BrpApiDtos.OntbindingHuwelijkPartnerschapInOnderzoek? destination, ResolutionContext context)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "050000" or
            "050700" or
            "050710" => new BrpApiDtos.OntbindingHuwelijkPartnerschapInOnderzoek
            {
                Datum = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            _ => null
        };
    }
}