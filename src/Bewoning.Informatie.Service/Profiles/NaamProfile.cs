using Brp.Shared.DtoMappers.Mappers;
using HC = Bewoning.Informatie.Service.Generated;
using Gba = Bewoning.Informatie.Service.Generated.Gba;

namespace Bewoning.Informatie.Service.Profiles;

public static class NaamMapper
{
    public static HC.Naam? Map(this Gba.NaamBasis? src, Gba.Geslachtsaanduiding geslacht)
    {
        return src != null
            ? new HC.Naam
            {
                VolledigeNaam = src.VolledigeNaam(geslacht),
            }
            : null;
    }
}
