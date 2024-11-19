using AutoMapper;
using HC = Bewoning.Informatie.Service.Generated;
using Gba = Bewoning.Informatie.Service.Generated.Gba;
using Brp.Shared.DtoMappers.Mappers;
namespace Bewoning.Informatie.Service.Profiles
{
    public class GeboorteProfile : Profile
    {
        public GeboorteProfile()
        {
            CreateMap<Gba.GbaGeboorte, HC.GeboorteBasis>()
                .ForMember(dest => dest.Datum, opt =>
                {
                    opt.PreCondition(src => src.Datum != null);
                    opt.MapFrom(src => src.Datum.Map());
                });
        }
    }
}
