using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;
using HC = Bewoning.Informatie.Service.Generated;
using Gba = Bewoning.Informatie.Service.Generated.Gba;

namespace Bewoning.Informatie.Service.Profiles;

public class GeboorteBasisProfile : Profile
{
    public GeboorteBasisProfile()
    {
        CreateMap<Gba.GeboorteBasis, HC.GeboorteBasis>()
            .ForMember(dest => dest.Datum, opt => opt.MapFrom(src => src.Datum.Map()))
            ;
    }
}
