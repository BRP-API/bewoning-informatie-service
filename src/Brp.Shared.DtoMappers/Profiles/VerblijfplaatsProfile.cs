using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;

namespace Brp.Shared.DtoMappers.Profiles;

public class VerblijfplaatsProfile : Profile
{
    public VerblijfplaatsProfile()
    {
        CreateMap<BrpDtos.GbaVerblijfplaats, BrpApiDtos.AbstractVerblijfplaats?>().ConvertUsing<VerblijfplaatsConverter>();

        CreateMap<BrpDtos.GbaVerblijfplaats, BrpApiDtos.VerblijfadresBuitenland>()
            .ForMember(dest => dest.Land, opt =>
            {
                opt.PreCondition(src => src.Land?.Code != "0000");
            })
            ;

        CreateMap<BrpDtos.GbaVerblijfplaats, BrpApiDtos.VerblijfadresBinnenland>()
            .ForMember(dest => dest.OfficieleStraatnaam, opt =>
            {
                opt.MapFrom(src => src.NaamOpenbareRuimte);
            })
            .ForMember(dest => dest.KorteStraatnaam, opt => 
            {
                opt.PreCondition(src => src.Straat != ".");
                opt.MapFrom(src => src.Straat);
            })
            .ForMember(dest => dest.Woonplaats, opt =>
            {
                opt.PreCondition(src => src.Woonplaats != ".");
                opt.MapFrom(src => src.Woonplaats);
            })
            ;

        CreateMap<BrpDtos.GbaVerblijfplaats, BrpApiDtos.VerblijfadresLocatie>();

        CreateMap<BrpDtos.GbaVerblijfplaats, BrpApiDtos.VerblijfplaatsOnbekend>()
            .ForMember(dest => dest.DatumVan, opt => opt.MapFrom(src => src.MapDatumVan()))
            .ForMember(dest => dest.DatumIngangGeldigheid, opt => opt.MapFrom(src => src.DatumIngangGeldigheid.Map()))
            ;

        CreateMap<BrpDtos.InOnderzoek, BrpApiDtos.AdresInOnderzoek?>().ConvertUsing<AdresInOnderzoekConverter>();
        CreateMap<BrpDtos.InOnderzoek, BrpApiDtos.VerblijfadresBinnenlandInOnderzoek?>().ConvertUsing<VerblijfadresBinnenlandInOnderzoekConverter>();
        CreateMap<BrpDtos.InOnderzoek, BrpApiDtos.VerblijfplaatsBuitenlandInOnderzoek?>().ConvertUsing<VerblijfplaatsBuitenlandInOnderzoekConverter>();
        CreateMap<BrpDtos.InOnderzoek, BrpApiDtos.VerblijfadresBuitenlandInOnderzoek?>().ConvertUsing<VerblijfadresBuitenlandInOnderzoekConverter>();
        CreateMap<BrpDtos.InOnderzoek, BrpApiDtos.LocatieInOnderzoek?>().ConvertUsing<LocatieInOnderzoekConverter>();
        CreateMap<BrpDtos.InOnderzoek, BrpApiDtos.VerblijfadresLocatieInOnderzoek?>().ConvertUsing<VerblijfadresLocatieInOnderzoekConverter>();
        CreateMap<BrpDtos.InOnderzoek, BrpApiDtos.VerblijfplaatsOnbekendInOnderzoek?>().ConvertUsing<VerblijfplaatsOnbekendInOnderzoekConverter>();

        CreateMap<BrpDtos.GbaVerblijfplaats, BrpApiDtos.VerblijfplaatsBuitenland>()
            .ForMember(dest => dest.DatumVan, opt => opt.MapFrom(src => src.DatumAanvangAdresBuitenland.Map()))
            .ForMember(dest => dest.DatumIngangGeldigheid, opt => opt.MapFrom(src => src.DatumIngangGeldigheid.Map()))
            .ForMember(dest => dest.Verblijfadres, opt => opt.MapFrom(src => src))
            ;

        CreateMap<BrpDtos.GbaVerblijfplaats, BrpApiDtos.Adres>()
            .ForMember(dest => dest.DatumVan, opt => opt.MapFrom(src => src.DatumAanvangAdreshouding.Map()))
            .ForMember(dest => dest.DatumIngangGeldigheid, opt => opt.MapFrom(src => src.DatumIngangGeldigheid.Map()))
            .ForMember(dest => dest.Verblijfadres, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.AdresseerbaarObjectIdentificatie, opt =>
            {
                opt.PreCondition(src => src.AdresseerbaarObjectIdentificatie != "0000000000000000");
                opt.MapFrom(src => src.AdresseerbaarObjectIdentificatie);
            })
            .ForMember(dest => dest.NummeraanduidingIdentificatie, opt =>
            {
                opt.PreCondition(src => src.NummeraanduidingIdentificatie != "0000000000000000");
                opt.MapFrom(src => src.NummeraanduidingIdentificatie);
            })
            .ForMember(dest => dest.IndicatieVastgesteldVerblijftNietOpAdres, opt =>
            {
                opt.PreCondition(src => src.InOnderzoek?.AanduidingGegevensInOnderzoek != null);
                opt.MapFrom(src => src.MapVastgesteldVerblijftNietOpAdres());
            })
            ;

        CreateMap<BrpDtos.GbaVerblijfplaats, BrpApiDtos.Locatie>()
            .ForMember(dest => dest.DatumVan, opt => opt.MapFrom(src => src.DatumAanvangAdreshouding.Map()))
            .ForMember(dest => dest.DatumIngangGeldigheid, opt => opt.MapFrom(src => src.DatumIngangGeldigheid.Map()))
            .ForMember(dest => dest.Verblijfadres, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.IndicatieVastgesteldVerblijftNietOpAdres, opt =>
            {
                opt.PreCondition(src => src.InOnderzoek?.AanduidingGegevensInOnderzoek != null);
                opt.MapFrom(src => src.MapVastgesteldVerblijftNietOpAdres());
            })
            ;
    }
}
