using Brp.Shared.DtoMappers.Mappers;

namespace Brp.Shared.DtoMappers.Profiles;

public static class GeboorteInOnderzoekExtensions
{
    public static void MapInOnderzoek(this BrpApiDtos.Geboorte? dest, BrpDtos.InOnderzoek? source)
    {
        if (dest != null && source != null)
        {
            dest.InOnderzoek = source.MapGeboorteInOnderzoek();
        }
    }

    public static void MapInOnderzoek(this BrpApiDtos.GeboorteBeperkt? dest, BrpDtos.InOnderzoek? source)
    {
        if (dest != null && source != null)
        {
            dest.InOnderzoek = source.MapGeboorteBeperktInOnderzoek();
        }
    }

    private static BrpApiDtos.GeboorteInOnderzoek? MapGeboorteInOnderzoek(this BrpDtos.InOnderzoek? source)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "010000" or
            "010300" or
            "020000" or
            "020300" or
            "030000" or
            "030300" or
            "050000" or
            "050300" or
            "090000" or
            "090300" => new BrpApiDtos.GeboorteInOnderzoek
            {
                Datum = true,
                Land = true,
                Plaats = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "010310" or
            "020310" or
            "030310" or
            "050310" or
            "090310" => new BrpApiDtos.GeboorteInOnderzoek
            {
                Datum = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "010320" or
            "020320" or
            "030320" or
            "050320" or
            "090320" => new BrpApiDtos.GeboorteInOnderzoek
            {
                Plaats = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "010330" or
            "020330" or
            "030330" or
            "050330" or
            "090330" => new BrpApiDtos.GeboorteInOnderzoek
            {
                Land = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            _ => null,
        };
    }

    private static BrpApiDtos.GeboorteInOnderzoekBeperkt? MapGeboorteBeperktInOnderzoek(this BrpDtos.InOnderzoek? source)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "010000" or
            "010300" or
            "010310" => new BrpApiDtos.GeboorteInOnderzoekBeperkt
            {
                Datum = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            _ => null,
        };
    }
}
