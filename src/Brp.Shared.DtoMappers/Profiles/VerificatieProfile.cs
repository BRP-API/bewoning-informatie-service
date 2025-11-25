using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;

namespace Brp.Shared.DtoMappers.Profiles;

public class VerificatieProfile : Profile
{
    public VerificatieProfile()
    {
        CreateMap<BrpDtos.GbaVerificatie, BrpApiDtos.Verificatie>()
            .ForMember(dest => dest.Datum, opt => opt.MapFrom(src => src.Datum.Map()))
            ;
    }
}
