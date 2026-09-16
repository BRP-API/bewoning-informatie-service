using HC = Bewoning.Informatie.Service.Generated;
using Gba = Bewoning.Informatie.Service.Generated.Gba;
using Bewoning.Informatie.Service.Mappers;
using Brp.Shared.DtoMappers.Mappers;

namespace Bewoning.Informatie.Service.Profiles;

public static class BewonerMapper
{
    public static IEnumerable<HC.Bewoner> Map(this IEnumerable<Gba.GbaBewoner> src)
    {
        return src.Select(Map);
    }

    public static HC.Bewoner Map(Gba.GbaBewoner src)
    {
        return new HC.Bewoner
        {
            Burgerservicenummer = src.Burgerservicenummer,
            Geboorte = src.Geboorte?.Map(),
            GeheimhoudingPersoonsgegevens = src.GeheimhoudingPersoonsgegevens > 0 ? true : null,
            Naam = src.Naam.Map(src.Geslacht),
            InOnderzoek = src.VerblijfplaatsInOnderzoek?.AanduidingGegevensInOnderzoek.MapInOnderzoek(),
        };
    }

    private static Brp.Shared.DtoMappers.BrpApiDtos.GeboorteBasis Map(this Brp.Shared.DtoMappers.BrpDtos.GeboorteBasis src)
    {
        return new Brp.Shared.DtoMappers.BrpApiDtos.GeboorteBasis
        {
            Datum = src.Datum.Map(),
        };
    }
}
