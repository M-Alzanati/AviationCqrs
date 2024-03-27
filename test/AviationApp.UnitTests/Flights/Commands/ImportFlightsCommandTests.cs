using AutoMapper;
using AviationApp.Application.Common.Interface;
using AviationApp.Application.Flights.Commands;
using AviationApp.Common.Clients.AviationStack;
using AviationApp.Domain.Interfaces;
using Moq;

namespace AviationApp.UnitTests.Flights.Commands;

public class ImportFlightsCommandTests
{
    [Test]
    public async Task Handle_GivenValidRequest_ShouldReturnTrue()
    {

    }

    [Test]
    public async Task Handle_GivenEmptyFlightData_ShouldNotInsertFlights()
    {

    }
}