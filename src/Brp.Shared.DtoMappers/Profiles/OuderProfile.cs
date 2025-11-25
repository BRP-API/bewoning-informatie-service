using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;

namespace Brp.Shared.DtoMappers.Profiles;

public class OuderProfile : Profile
{
    public OuderProfile()
    {
        CreateMap<BrpDtos.GbaOuder, BrpApiDtos.Ouder>()
            .BeforeMap((src, dest) =>
            {
                if (src.InOnderzoek == null) return;

                src.Naam ??= new CommonDtos.NaamBasis();

                src.Geboorte ??= new BrpDtos.GbaGeboorte();
            })
            .AfterMap((src, dest) =>
            {
                dest.Naam.MapInOnderzoek(src.InOnderzoek);

                dest.Geboorte.MapInOnderzoek(src.InOnderzoek);
            })
            .ForMember(dest => dest.DatumIngangFamilierechtelijkeBetrekking, opt => opt.MapFrom(src => src.DatumIngangFamilierechtelijkeBetrekking.Map()))
            ;

        CreateMap<BrpDtos.InOnderzoek, BrpApiDtos.OuderInOnderzoek?>().ConvertUsing<OuderInOnderzoekConverter>();
    }
}
