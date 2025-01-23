using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;

namespace Brp.Shared.DtoMappers.Profiles;

public class NaamVolledigeNaamProfile : Profile
{
    public NaamVolledigeNaamProfile()
    {
        CreateMap<CommonDtos.NaamBasis, BrpApiDtos.NaamVolledigeNaam>()
            .AfterMap((src, dest) =>
            {
                if(src.AdellijkeTitelPredicaat is null)
                {
                    dest.VolledigeNaam = src.VolledigeNaam(null);
                }
            })
            ;
    }
}
