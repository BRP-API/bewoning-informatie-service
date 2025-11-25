using AutoMapper;
using Brp.Shared.DtoMappers.BrpApiDtos;
using Brp.Shared.DtoMappers.BrpDtos;
using Brp.Shared.DtoMappers.Mappers;

namespace Brp.Shared.DtoMappers.Profiles;

public class VerblijfstitelProfile : Profile
{
    public VerblijfstitelProfile()
    {
        CreateMap<GbaVerblijfstitel, Verblijfstitel>()
            .ForMember(dest => dest.DatumEinde, opt => opt.MapFrom(src => src.DatumEinde.Map()))
            .ForMember(dest => dest.DatumIngang, opt => opt.MapFrom(src => src.DatumIngang.Map()))
            .ForMember(dest => dest.Aanduiding, opt =>
            {
                opt.PreCondition(src => src.Aanduiding?.Code != "98");
                opt.MapFrom(src => src.Aanduiding);
            });

        CreateMap<BrpDtos.InOnderzoek, VerblijfstitelInOnderzoek?>().ConvertUsing<VerblijfstitelInOnderzoekConverter>();
    }
}
