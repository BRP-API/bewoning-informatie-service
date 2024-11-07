using AutoMapper;
using HC = Bewoning.Informatie.Service.Generated;
using Gba = Bewoning.Informatie.Service.Generated.Gba;
using Bewoning.Informatie.Service.Mappers;
using System.Text.RegularExpressions;

namespace Bewoning.Informatie.Service.Profiles;

public class BewonerProfile : Profile
{
    public BewonerProfile()
    {
        CreateMap<Gba.GbaBewoner, HC.Bewoner>()
             .ForMember(dest => dest.Leeftijd, opt =>
             {
                 opt.MapFrom(src => src.Geboorte.Datum.Map().Leeftijd());
             })
            .AfterMap((src, dest) =>
            {
                if (src.Naam is null) return;
                dest.Naam.VolledigeNaam = src.Naam.VolledigeNaam(src.Geslacht);
            });
    }
}