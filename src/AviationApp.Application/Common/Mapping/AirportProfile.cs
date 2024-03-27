using AutoMapper;
using AviationApp.Common.Clients.AviationStack;
using AviationApp.Domain.Entities;

namespace AviationApp.Application.Common.Mapping;

public class AirportProfile : Profile
{
    public AirportProfile()
    {
        CreateMap<AirportInfo, Airport>()
            .ForMember(e => e.AirportName, c => c.MapFrom(x => x.AirportName))
            .ForMember(e => e.Timezone, c => c.MapFrom(x => x.Timezone))
            .ForMember(e => e.AirportId, c => c.MapFrom(x => x.AirportId))
            .ForMember(e => e.CountryName, c => c.MapFrom(x => x.CountryName));
    }
}