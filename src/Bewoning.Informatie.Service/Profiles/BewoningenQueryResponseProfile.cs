using AutoMapper;
using HC = Bewoning.Informatie.Service.Generated;
using Gba = Bewoning.Informatie.Service.Generated.Gba;

namespace Bewoning.Informatie.Service.Profiles;


public class BewoningenQueryResponseProfile : Profile
{
    public BewoningenQueryResponseProfile()
    {
        CreateMap<Gba.GbaBewoning, HC.Bewoning>();

        CreateMap<Gba.GbaBewoningenQueryResponse, HC.BewoningenQueryResponse>();
    }
}
