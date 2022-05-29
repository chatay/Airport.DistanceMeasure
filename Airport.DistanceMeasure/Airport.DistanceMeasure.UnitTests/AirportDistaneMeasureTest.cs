using Airport.DistanceMeasure.API.Controllers;
using Airport.DistanceMeasure.Application.DTOs;
using Airport.DistanceMeasure.Application.Exceptions;
using Airport.DistanceMeasure.Application.Interfaces;
using Airport.DistanceMeasure.Application.Options;
using Airport.DistanceMeasure.Application.Validation.FluentValidation;
using Airport.DistanceMeasure.Infrastructure.Shared.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Airport.DistanceMeasure.UnitTests
{
    public class AirportDistaneMeasureTest
    {
        private Mock<HttpMessageHandler> _httpMessageHandler;
        private Mock<IGetAirportsService> _getAirportsService;
        private Mock<IAirportDistanceMeasureService> _airportdistanceService;
        private Mock<ILogger<AirportDistanceMeasureService>> _logger;
        private AirportMeasureDistanceController _measureDistanceController;
        private Mock<IOptions<AirportConfigurations>> _configuration;
        private const string baseAddress = "https://places-dev.cteleport.com/airports/";
        private readonly IOptions<AirportConfigurations> _options = Options.Create(new AirportConfigurations()
        { BaseAddress =new Uri("https://places-dev.cteleport.com/airports/") });

        public AirportDistaneMeasureTest()
        {
            _logger = new Mock<ILogger<AirportDistanceMeasureService>>();
            _httpMessageHandler = new Mock<HttpMessageHandler>();
            _getAirportsService = new Mock<IGetAirportsService>();
            _airportdistanceService = new Mock<IAirportDistanceMeasureService>();
            _configuration = new Mock<IOptions<AirportConfigurations>>();
            _measureDistanceController = new AirportMeasureDistanceController(_airportdistanceService.Object, _options);
        }
        [Fact]
        public async void Return_Success_When_Service_Is_Up()
        {
            AirportIataCodesRequest airportIataCodes = new AirportIataCodesRequest()
            {
                FromIataCode = "IST",
                ToIataCode = "AYT"
            };

            AirportDTO airportDistanceDTO = new AirportDTO()
            {
                Country = "",
                CityIata = "",
                Iata = "",
                City = "",
                TimezoneRegionName = "",
                CountryIata = "",
                Rating = 1,
                Name = "",
                Location = new Location()
                {
                    Lon = 1,
                    Lat = 1,
                },
                Type = "",
                Hubs = 1,
            };

            _airportdistanceService.Setup(service => service.GetAirportDistance(It.IsAny<AirportIataCodesRequest>(), It.IsAny<string>())).ReturnsAsync(GetSuccessDistanceResponse());

            var result = await _measureDistanceController.MeasureDistanceBetweenAirports(FillIataCode());

            Assert.IsType<AirportDistanceDTO>(result);
        }
        [Fact]
        public void Should_have_error_when_val_is_zero_fluent_validation()
        {
            var validator = new IataCodesValidator();

            AirportIataCodesRequest airportDistanceDTO = new AirportIataCodesRequest();

            var result = validator.Validate(airportDistanceDTO);

            Assert.Contains(result.Errors, x => x.ErrorMessage.Contains("Destiny IATA code is not valid!"));
        }
        private AirportIataCodesRequest FillIataCode()
        {
            AirportIataCodesRequest airportIataCodes = new AirportIataCodesRequest()
            {
                FromIataCode = "IST",
                ToIataCode = "AYT"
            };

            return airportIataCodes;
        }
        private AirportIataCodesRequest EmptyIataCode()
        {
            AirportIataCodesRequest airportIataCodes = new AirportIataCodesRequest()
            {
                FromIataCode = "",
                ToIataCode = ""
            };

            return airportIataCodes;
        }
        private AirportDistanceDTO GetSuccessDistanceResponse()
        {
            AirportDistanceDTO airportDistanceDTO = new AirportDistanceDTO()
            {
                Distance = "464234.12"
            };

            return airportDistanceDTO;
        }
    };
}
