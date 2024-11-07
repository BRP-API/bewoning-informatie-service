using AutoMapper;
using HC = Bewoning.Informatie.Service.Generated;
using Gba = Bewoning.Informatie.Service.Generated.Gba;

namespace Bewoning.Informatie.Service.Profiles;

public class NaamProfile : Profile
{
    public NaamProfile()
    {
        CreateMap<Gba.GbaNaamPersoon, HC.NaamPersoon>();
    }
}
