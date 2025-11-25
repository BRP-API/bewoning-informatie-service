using Brp.Shared.DtoMappers.Mappers;

namespace Brp.Shared.DtoMappers.Profiles;

public static class NaamInOnderzoekExtensions
{
    public static void MapInOnderzoek(this BrpApiDtos.NaamGerelateerde? dest, BrpDtos.InOnderzoek? source)
    {
        if (dest != null && source != null)
        {
            dest.InOnderzoek = source.MapNaamGerelateerdeInOnderzoek();
        }
    }

    public static void MapInOnderzoek(this BrpApiDtos.NaamPersoon? dest, BrpDtos.InOnderzoek? source)
    {
        if (dest != null && source != null)
        {
            dest.InOnderzoek = source.MapNaamPersoonInOnderzoek();
        }
    }

    public static void MapInOnderzoek(this BrpApiDtos.NaamPersoonBeperkt? dest, BrpDtos.InOnderzoek? source)
    {
        if (dest != null && source != null)
        {
            dest.InOnderzoek = source.MapNaamPersoonBeperktInOnderzoek();
        }
    }

    private static BrpApiDtos.NaamPersoonInOnderzoek? MapNaamPersoonInOnderzoek(this BrpDtos.InOnderzoek? source)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "010000" => new BrpApiDtos.NaamPersoonInOnderzoek
            {
                Voornamen = true,
                AdellijkeTitelPredicaat = true,
                Voorvoegsel = true,
                Geslachtsnaam = true,
                AanduidingNaamgebruik = true,
                Voorletters = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "010200" => new BrpApiDtos.NaamPersoonInOnderzoek
            {
                Voornamen = true,
                AdellijkeTitelPredicaat = true,
                Voorvoegsel = true,
                Geslachtsnaam = true,
                Voorletters = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "010210" => new BrpApiDtos.NaamPersoonInOnderzoek
            {
                Voornamen = true,
                Voorletters = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "010220" => new BrpApiDtos.NaamPersoonInOnderzoek
            {
                AdellijkeTitelPredicaat = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "010230" => new BrpApiDtos.NaamPersoonInOnderzoek
            {
                Voorvoegsel = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "010240" => new BrpApiDtos.NaamPersoonInOnderzoek
            {
                Geslachtsnaam = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "010400" or "010410" => new BrpApiDtos.NaamPersoonInOnderzoek
            {
                VolledigeNaam = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "016100" or "016110" => new BrpApiDtos.NaamPersoonInOnderzoek
            {
                AanduidingNaamgebruik = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            _ => null
        };
    }

    private static BrpApiDtos.NaamPersoonInOnderzoekBeperkt? MapNaamPersoonBeperktInOnderzoek(this BrpDtos.InOnderzoek? source)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "010000" => new BrpApiDtos.NaamPersoonInOnderzoekBeperkt
            {
                Voornamen = true,
                AdellijkeTitelPredicaat = true,
                Voorvoegsel = true,
                Geslachtsnaam = true,
                Voorletters = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "010200" => new BrpApiDtos.NaamPersoonInOnderzoekBeperkt
            {
                Voornamen = true,
                AdellijkeTitelPredicaat = true,
                Voorvoegsel = true,
                Geslachtsnaam = true,
                Voorletters = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "010210" => new BrpApiDtos.NaamPersoonInOnderzoekBeperkt
            {
                Voornamen = true,
                Voorletters = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "010220" => new BrpApiDtos.NaamPersoonInOnderzoekBeperkt
            {
                AdellijkeTitelPredicaat = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "010230" => new BrpApiDtos.NaamPersoonInOnderzoekBeperkt
            {
                Voorvoegsel = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "010240" => new BrpApiDtos.NaamPersoonInOnderzoekBeperkt
            {
                Geslachtsnaam = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "010400" or
            "010410" => new BrpApiDtos.NaamPersoonInOnderzoekBeperkt
            {
                VolledigeNaam = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            _ => null
        };
    }

    private static BrpApiDtos.NaamInOnderzoek? MapNaamGerelateerdeInOnderzoek(this BrpDtos.InOnderzoek? source)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "020000" or
            "020200" or
            "030000" or
            "030200" or
            "050000" or
            "050200" or
            "090000" or
            "090200" => new BrpApiDtos.NaamInOnderzoek
            {
                Voornamen = true,
                AdellijkeTitelPredicaat = true,
                Voorvoegsel = true,
                Geslachtsnaam = true,
                Voorletters = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "020210" or
            "030210" or
            "050210" or
            "090210" => new BrpApiDtos.NaamInOnderzoek
            {
                Voornamen = true,
                Voorletters = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "020220" or
            "030220" or
            "050220" or
            "090220" => new BrpApiDtos.NaamInOnderzoek
            {
                AdellijkeTitelPredicaat = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "020230" or
            "030230" or
            "050230" or
            "090230" => new BrpApiDtos.NaamInOnderzoek
            {
                Voorvoegsel = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "020240" or
            "030240" or
            "050240" or
            "090240" => new BrpApiDtos.NaamInOnderzoek
            {
                Geslachtsnaam = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            _ => null
        };
    }
}
