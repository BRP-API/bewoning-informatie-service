using AutoMapper;

namespace Brp.Shared.DtoMappers.Profiles;

public class PartnerProfile : Profile
{
    public PartnerProfile()
    {
        CreateMap<BrpDtos.GbaPartner, BrpApiDtos.Partner>()
            .BeforeMap((src, dest) =>
            {
                if(src.InOnderzoek != null)
                {
                    src.Naam ??= new CommonDtos.NaamBasis();

                    src.Geboorte ??= new BrpDtos.GbaGeboorte();
                }
                if(src.AangaanHuwelijkPartnerschap != null || src.InOnderzoek != null)
                {
                    src.AangaanHuwelijkPartnerschap ??= new BrpDtos.GbaAangaanHuwelijkPartnerschap();
                    src.AangaanHuwelijkPartnerschap.InOnderzoek = src.InOnderzoek;
                }
                if(src.OntbindingHuwelijkPartnerschap != null || src.InOnderzoek != null)
                {
                    src.OntbindingHuwelijkPartnerschap ??= new BrpDtos.GbaOntbindingHuwelijkPartnerschap();
                    src.OntbindingHuwelijkPartnerschap.InOnderzoek = src.InOnderzoek;
                }
            })
            .AfterMap((src, dest) =>
            {
                dest.Naam.MapInOnderzoek(src.InOnderzoek);

                dest.Geboorte.MapInOnderzoek(src.InOnderzoek);
            })
            .ForMember(dest => dest.SoortVerbintenis, opt =>
            {
                opt.PreCondition(src => src.SoortVerbintenis?.Code != ".");
                opt.MapFrom(src => src.SoortVerbintenis);
            });

        CreateMap<BrpDtos.InOnderzoek, BrpApiDtos.PartnerInOnderzoek?>().ConvertUsing<PartnerInOnderzoekConverter>();
    }
}
