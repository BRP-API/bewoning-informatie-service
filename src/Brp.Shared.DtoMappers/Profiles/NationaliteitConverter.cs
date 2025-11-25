using AutoMapper;

namespace Brp.Shared.DtoMappers.Profiles;

public class NationaliteitConverter : ITypeConverter<BrpDtos.GbaNationaliteit, BrpApiDtos.AbstractNationaliteit?>
{
    public BrpApiDtos.AbstractNationaliteit? Convert(BrpDtos.GbaNationaliteit source, BrpApiDtos.AbstractNationaliteit? destination, ResolutionContext context)
    {
        return source switch
        {
            { Nationaliteit.Code: var code } when code == "0002" => context.Mapper.Map<BrpApiDtos.BehandeldAlsNederlander>(source),
            { Nationaliteit.Code: var code } when code == "0500" => context.Mapper.Map<BrpApiDtos.VastgesteldNietNederlander>(source),
            { Nationaliteit.Code: var code } when code == "0499" => context.Mapper.Map<BrpApiDtos.Staatloos>(source),
            { Nationaliteit.Code: var code } when code != "0000" => context.Mapper.Map<BrpApiDtos.NationaliteitBekend>(source),
            { AanduidingBijzonderNederlanderschap: var code } when code == "B" => context.Mapper.Map<BrpApiDtos.BehandeldAlsNederlander>(source),
            { AanduidingBijzonderNederlanderschap: var code } when code == "V" => context.Mapper.Map<BrpApiDtos.VastgesteldNietNederlander>(source),
            _ => context.Mapper.Map<BrpApiDtos.NationaliteitOnbekend>(source)
        };
    }
}
