using HC = Bewoning.Informatie.Service.Generated;
using Gba = Bewoning.Informatie.Service.Generated.Gba;

namespace Bewoning.Informatie.Service.Profiles;

public static class BewoningMapper
{
    public static IEnumerable<HC.Bewoning> Map(this IEnumerable<Gba.GbaBewoning> src)
    {
        return src.Select(Map);
    }

    public static HC.Bewoning Map(this Gba.GbaBewoning src)
    {
        return new HC.Bewoning
        {
            AdresseerbaarObjectIdentificatie = src.AdresseerbaarObjectIdentificatie,
            Bewoners = [.. src.Bewoners.Map()],
            MogelijkeBewoners = [.. src.MogelijkeBewoners.Map()],
            IndicatieVeelBewoners = src.IndicatieVeelBewoners,
            Periode = src.Periode.Map(),
        };
    }
}
