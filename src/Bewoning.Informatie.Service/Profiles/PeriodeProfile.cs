using HC = Bewoning.Informatie.Service.Generated;
using Gba = Bewoning.Informatie.Service.Generated.Gba;

namespace Bewoning.Informatie.Service.Profiles;

public static class PeriodeMapper
{
    public static HC.Periode Map(this Gba.Periode src)
    {
        return new HC.Periode
        {
            DatumVan = src.DatumVan,
            DatumTot = src.DatumTot,
        };
    }
}
