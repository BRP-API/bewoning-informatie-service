using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;

namespace Brp.Shared.DtoMappers.Profiles;

public class AdresInOnderzoekConverter : ITypeConverter<BrpDtos.InOnderzoek, BrpApiDtos.AdresInOnderzoek?>
{
    public BrpApiDtos.AdresInOnderzoek? Convert(BrpDtos.InOnderzoek source, BrpApiDtos.AdresInOnderzoek? destination, ResolutionContext context)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "080000" or
            "089999" => new BrpApiDtos.AdresInOnderzoek
            {
                AdresseerbaarObjectIdentificatie = true,
                DatumIngangGeldigheid = true,
                DatumVan = true,
                FunctieAdres = true,
                NummeraanduidingIdentificatie = true,
                Type = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "081000" => new BrpApiDtos.AdresInOnderzoek
            {
                DatumVan = true,
                FunctieAdres = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "081010" => new BrpApiDtos.AdresInOnderzoek
            {
                FunctieAdres = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "081030" or
            "081320" => new BrpApiDtos.AdresInOnderzoek
            {
                DatumVan = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "081100" => new BrpApiDtos.AdresInOnderzoek
            {
                AdresseerbaarObjectIdentificatie = true,
                NummeraanduidingIdentificatie = true,
                Type = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "081110" => new BrpApiDtos.AdresInOnderzoek
            {
                Type = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "081180" => new BrpApiDtos.AdresInOnderzoek
            {
                AdresseerbaarObjectIdentificatie = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "081190" => new BrpApiDtos.AdresInOnderzoek
            {
                NummeraanduidingIdentificatie = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "081300" => new BrpApiDtos.AdresInOnderzoek
            {
                DatumVan = true,
                Type = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "088500" or
            "088510" => new BrpApiDtos.AdresInOnderzoek
            {
                DatumIngangGeldigheid = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            _ => null,
        };
    }
}

public class VerblijfadresBinnenlandInOnderzoekConverter : ITypeConverter<BrpDtos.InOnderzoek, BrpApiDtos.VerblijfadresBinnenlandInOnderzoek?>
{
    public BrpApiDtos.VerblijfadresBinnenlandInOnderzoek? Convert(BrpDtos.InOnderzoek source, BrpApiDtos.VerblijfadresBinnenlandInOnderzoek? destination, ResolutionContext context)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "080000" or
            "081100" or
            "089999" => new BrpApiDtos.VerblijfadresBinnenlandInOnderzoek
            {
                AanduidingBijHuisnummer = true,
                Huisletter = true,
                Huisnummer = true,
                Huisnummertoevoeging = true,
                KorteStraatnaam = true,
                Postcode = true,
                OfficieleStraatnaam = true,
                Woonplaats = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "080900" or
            "080910" => new BrpApiDtos.VerblijfadresBinnenlandInOnderzoek
            {
                Woonplaats = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "081110" => new BrpApiDtos.VerblijfadresBinnenlandInOnderzoek
            {
                KorteStraatnaam = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "081115" => new BrpApiDtos.VerblijfadresBinnenlandInOnderzoek
            {
                OfficieleStraatnaam = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "081120" => new BrpApiDtos.VerblijfadresBinnenlandInOnderzoek
            {
                Huisnummer = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "081130" => new BrpApiDtos.VerblijfadresBinnenlandInOnderzoek
            {
                Huisletter = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "081140" => new BrpApiDtos.VerblijfadresBinnenlandInOnderzoek
            {
                Huisnummertoevoeging = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "081150" => new BrpApiDtos.VerblijfadresBinnenlandInOnderzoek
            {
                AanduidingBijHuisnummer = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "081160" => new BrpApiDtos.VerblijfadresBinnenlandInOnderzoek
            {
                Postcode = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "081170" => new BrpApiDtos.VerblijfadresBinnenlandInOnderzoek
            {
                Woonplaats = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            _ => null,
        };
    }
}

public class VerblijfplaatsBuitenlandInOnderzoekConverter : ITypeConverter<BrpDtos.InOnderzoek, BrpApiDtos.VerblijfplaatsBuitenlandInOnderzoek?>
{
    public BrpApiDtos.VerblijfplaatsBuitenlandInOnderzoek? Convert(BrpDtos.InOnderzoek source, BrpApiDtos.VerblijfplaatsBuitenlandInOnderzoek? destination, ResolutionContext context)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "080000" => new BrpApiDtos.VerblijfplaatsBuitenlandInOnderzoek
            {
                DatumIngangGeldigheid = true,
                DatumVan = true,
                Type = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "081300" => new BrpApiDtos.VerblijfplaatsBuitenlandInOnderzoek
            {
                DatumVan = true,
                Type = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "081310" => new BrpApiDtos.VerblijfplaatsBuitenlandInOnderzoek
            {
                Type = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "081320" => new BrpApiDtos.VerblijfplaatsBuitenlandInOnderzoek
            {
                DatumVan = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "088500" or
            "088510" => new BrpApiDtos.VerblijfplaatsBuitenlandInOnderzoek
            {
                DatumIngangGeldigheid = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            _ => null,
        };
    }
}

public class VerblijfadresBuitenlandInOnderzoekConverter : ITypeConverter<BrpDtos.InOnderzoek, BrpApiDtos.VerblijfadresBuitenlandInOnderzoek?>
{
    public BrpApiDtos.VerblijfadresBuitenlandInOnderzoek? Convert(BrpDtos.InOnderzoek source, BrpApiDtos.VerblijfadresBuitenlandInOnderzoek? destination, ResolutionContext context)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "080000" or 
            "081300"=> new BrpApiDtos.VerblijfadresBuitenlandInOnderzoek
            {
                Regel1 = true,
                Regel2 = true,
                Regel3 = true,
                Land = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "081310" => new BrpApiDtos.VerblijfadresBuitenlandInOnderzoek
            {
                Land = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "081330" => new BrpApiDtos.VerblijfadresBuitenlandInOnderzoek
            {
                Regel1 = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "081340" => new BrpApiDtos.VerblijfadresBuitenlandInOnderzoek
            {
                Regel2 = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "081350" => new BrpApiDtos.VerblijfadresBuitenlandInOnderzoek
            {
                Regel3 = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            _ => null,
        };
    }
}

public class LocatieInOnderzoekConverter : ITypeConverter<BrpDtos.InOnderzoek, BrpApiDtos.LocatieInOnderzoek?>
{
    public BrpApiDtos.LocatieInOnderzoek? Convert(BrpDtos.InOnderzoek source, BrpApiDtos.LocatieInOnderzoek? destination, ResolutionContext context)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "080000" or
            "089999" => new BrpApiDtos.LocatieInOnderzoek
            {
                DatumIngangGeldigheid = true,
                DatumVan = true,
                FunctieAdres = true,
                Type = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "081000" => new BrpApiDtos.LocatieInOnderzoek
            {
                DatumVan = true,
                FunctieAdres = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "081010" => new BrpApiDtos.LocatieInOnderzoek
            {
                FunctieAdres = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "081030" => new BrpApiDtos.LocatieInOnderzoek
            {
                DatumVan = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "081200" or
            "081210" => new BrpApiDtos.LocatieInOnderzoek
            {
                Type = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "088500" or
            "088510" => new BrpApiDtos.LocatieInOnderzoek
            {
                DatumIngangGeldigheid = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            _ => null,
        };
    }
}

public class VerblijfadresLocatieInOnderzoekConverter : ITypeConverter<BrpDtos.InOnderzoek, BrpApiDtos.VerblijfadresLocatieInOnderzoek?>
{
    public BrpApiDtos.VerblijfadresLocatieInOnderzoek? Convert(BrpDtos.InOnderzoek source, BrpApiDtos.VerblijfadresLocatieInOnderzoek? destination, ResolutionContext context)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "080000" or
            "081200" or
            "081210" or
            "089999" => new BrpApiDtos.VerblijfadresLocatieInOnderzoek
            {
                Locatiebeschrijving = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            _ => null,
        };
    }
}

public class VerblijfplaatsOnbekendInOnderzoekConverter : ITypeConverter<BrpDtos.InOnderzoek, BrpApiDtos.VerblijfplaatsOnbekendInOnderzoek?>
{
    public BrpApiDtos.VerblijfplaatsOnbekendInOnderzoek? Convert(BrpDtos.InOnderzoek source, BrpApiDtos.VerblijfplaatsOnbekendInOnderzoek? destination, ResolutionContext context)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "080000" => new BrpApiDtos.VerblijfplaatsOnbekendInOnderzoek
            {
                DatumIngangGeldigheid = true,
                DatumVan = true,
                Type = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "081300" => new BrpApiDtos.VerblijfplaatsOnbekendInOnderzoek
            {
                DatumVan = true,
                Type = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "081310" => new BrpApiDtos.VerblijfplaatsOnbekendInOnderzoek
            {
                Type = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "081320" => new BrpApiDtos.VerblijfplaatsOnbekendInOnderzoek
            {
                DatumVan = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "088500" or
            "088510" => new BrpApiDtos.VerblijfplaatsOnbekendInOnderzoek
            {
                DatumIngangGeldigheid = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            _ => null,
        };
    }
}
