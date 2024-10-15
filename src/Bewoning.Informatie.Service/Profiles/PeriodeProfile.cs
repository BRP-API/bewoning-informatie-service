using AutoMapper;
using HC = Bewoning.Informatie.Service.Generated;
using Gba = Bewoning.Informatie.Service.Generated.Gba;

namespace Bewoning.Informatie.Service.Profiles;

public class PeriodeProfile : Profile
{
    public PeriodeProfile()
    {
        CreateMap<Gba.Periode, HC.Periode>();
    }
}
