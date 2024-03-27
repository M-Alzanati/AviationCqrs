using AutoMapper;
using AviationApp.Application.Flights.Queries;
using AviationApp.Common.Clients.AviationStack;
using Flight = AviationApp.Domain.Entities.Flight;

namespace AviationApp.Application.Common.Mapping;

public class FlightProfile : Profile
{
    public FlightProfile()
    {
        CreateMap<Flight, FlightDto>();
        
        CreateMap<FlightInfo, Flight>()
            .ForMember(e => e.AirlineName, opt => opt.MapFrom(e => e.Airline!.Name))
            .ForMember(e => e.FlightDate, opt => opt.MapFrom(e => DateTime.Parse(e.FlightDate!)))
            .ForMember(e => e.FlightNumber, opt => opt.MapFrom(e => e.Flight!.Number))
            .ForMember(e => e.FlightStatus, opt => opt.MapFrom(e => e.FlightStatus))
            .ForMember(e => e.ArrivalAirport, opt => opt.MapFrom(e => e.Arrival!.Airport))
            .ForMember(e => e.ArrivalScheduled, opt => opt.MapFrom(e => e.Arrival!.Scheduled))
            .ForMember(e => e.DepartureAirport, opt => opt.MapFrom(e => e.Departure!.Airport))
            .ForMember(e => e.DepartureScheduled, opt => opt.MapFrom(e => e.Departure!.Scheduled))
            .ForMember(e => e.AirlineName, opt => opt.MapFrom(e => e.Airline!.Name))
            .ForMember(e => e.ArrivalIataCode, opt => opt.MapFrom(e => e.Arrival!.Iata))
            .ForMember(e => e.DepartureIataCode, opt => opt.MapFrom(e => e.Departure!.Iata));
    }
}