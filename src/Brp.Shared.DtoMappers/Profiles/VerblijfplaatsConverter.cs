using AutoMapper;

namespace Brp.Shared.DtoMappers.Profiles;

public static class VerblijfplaatsConverterExtensions
{
    public static bool IsOnbekendVerblijfplaatsBuitenland(this BrpDtos.GbaVerblijfplaats source) =>
        source.Land != null &&
        source.Land.Code == "0000";

    public static bool IsVerblijfplaatsBuitenland(this BrpDtos.GbaVerblijfplaats source) =>
        source.Land != null &&
        source.Land.Code != "0000";

    public static bool IsAdres(this BrpDtos.GbaVerblijfplaats source) => !string.IsNullOrWhiteSpace(source.Straat);

    public static bool IsLocatie(this BrpDtos.GbaVerblijfplaats source) => !string.IsNullOrWhiteSpace(source.Locatiebeschrijving);
}

public class VerblijfplaatsConverter : ITypeConverter<BrpDtos.GbaVerblijfplaats, BrpApiDtos.AbstractVerblijfplaats?>
{
    public BrpApiDtos.AbstractVerblijfplaats? Convert(BrpDtos.GbaVerblijfplaats source, BrpApiDtos.AbstractVerblijfplaats? destination, ResolutionContext context)
    {
        if (source == null)
        {
            return null;
        }
        if (source.IsOnbekendVerblijfplaatsBuitenland())
        {
            return context.Mapper.Map<BrpApiDtos.VerblijfplaatsOnbekend>(source);
        }
        if(source.IsVerblijfplaatsBuitenland())
        {
            return context.Mapper.Map<BrpApiDtos.VerblijfplaatsBuitenland>(source);
        }
        if(source.IsAdres())
        {
            return context.Mapper.Map<BrpApiDtos.Adres>(source);
        }
        if (source.IsLocatie())
        {
            return context.Mapper.Map<BrpApiDtos.Locatie>(source);
        }
        return null;
    }
}
