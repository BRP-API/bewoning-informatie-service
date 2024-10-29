using AutoMapper;
using HC = Bewoning.Informatie.Service.Generated;
using Gba = Bewoning.Informatie.Service.Generated.Gba;

namespace Bewoning.Informatie.Service.Profiles;

public class BewoningProfile : Profile
{
    public BewoningProfile()
    {
        CreateMap<Gba.GbaBewoning, HC.Bewoning>();
    }
}
