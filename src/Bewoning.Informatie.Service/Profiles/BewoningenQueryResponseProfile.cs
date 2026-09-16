using HC = Bewoning.Informatie.Service.Generated;
using Gba = Bewoning.Informatie.Service.Generated.Gba;

namespace Bewoning.Informatie.Service.Profiles;

public static class BewoningenQueryResponseMapper
{
    public static HC.BewoningenQueryResponse Map(this Gba.GbaBewoningenQueryResponse src)
    {
        return new HC.BewoningenQueryResponse
            {
                Bewoningen = [.. src.Bewoningen.Map()],
            };
    }
}
