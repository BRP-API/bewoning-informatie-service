using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;

namespace Brp.Shared.DtoMappers.Profiles;

public class NationaliteitProfile : Profile
{
    public NationaliteitProfile()
    {
        CreateMap<BrpDtos.GbaNationaliteit, BrpApiDtos.AbstractNationaliteit?>().ConvertUsing<NationaliteitConverter>();

        CreateMap<BrpDtos.GbaNationaliteit, BrpApiDtos.NationaliteitBekend>()
            .ForMember(dest => dest.Nationaliteit, opt => opt.MapFrom(src => src.Nationaliteit))
            .ForMember(dest => dest.DatumIngangGeldigheid, opt => opt.MapFrom(src => src.DatumIngangGeldigheid.Map()))
            .ForMember(dest => dest.RedenOpname, opt => opt.PreCondition(src => src.RedenOpname?.Code != "000"))
            ;

        CreateMap<BrpDtos.InOnderzoek, BrpApiDtos.NationaliteitBekendInOnderzoek?>().ConvertUsing<NationaliteitInOnderzoekConverter>();

        CreateMap<BrpDtos.GbaNationaliteit, BrpApiDtos.BehandeldAlsNederlander>()
            .ForMember(dest => dest.DatumIngangGeldigheid, opt => opt.MapFrom(src => src.DatumIngangGeldigheid.Map()))
            .ForMember(dest => dest.RedenOpname, opt => opt.PreCondition(src => src.RedenOpname?.Code != "000"))
            ;

        CreateMap<BrpDtos.GbaNationaliteit, BrpApiDtos.VastgesteldNietNederlander>()
            .ForMember(dest => dest.DatumIngangGeldigheid, opt => opt.MapFrom(src => src.DatumIngangGeldigheid.Map()))
            .ForMember(dest => dest.RedenOpname, opt => opt.PreCondition(src => src.RedenOpname?.Code != "000"))
            ;

        CreateMap<BrpDtos.InOnderzoek, BrpApiDtos.BijzonderNederlanderschapInOnderzoek?>().ConvertUsing<BijzonderNederlanderschapInOnderzoekConverter>();

        CreateMap<BrpDtos.GbaNationaliteit, BrpApiDtos.Staatloos>()
            .ForMember(dest => dest.DatumIngangGeldigheid, opt => opt.MapFrom(src => src.DatumIngangGeldigheid.Map()))
            .ForMember(dest => dest.RedenOpname, opt => opt.PreCondition(src => src.RedenOpname?.Code != "000"))
            ;

        CreateMap<BrpDtos.InOnderzoek, BrpApiDtos.StaatloosInOnderzoek?>().ConvertUsing<StaatloosInOnderzoekConverter>();

        CreateMap<BrpDtos.GbaNationaliteit, BrpApiDtos.NationaliteitOnbekend>()
            .ForMember(dest => dest.DatumIngangGeldigheid, opt => opt.MapFrom(src => src.DatumIngangGeldigheid.Map()))
            .ForMember(dest => dest.RedenOpname, opt => opt.PreCondition(src => src.RedenOpname?.Code != "000"))
            ;

        CreateMap<BrpDtos.InOnderzoek, BrpApiDtos.NationaliteitOnbekendInOnderzoek?>().ConvertUsing<NationaliteitOnbekendInOnderzoekConverter>();
    }
}
