using Airport.DistanceMeasure.Application.DTOs;
using Airport.DistanceMeasure.Application.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Airport.DistanceMeasure.Infrastructure.Shared.Services
{
    public class AirportDistanceMeasureService : BaseService<AirportDistanceMeasureService>, IAirportDistanceMeasureService
    {
        private readonly IGetAirportsService _getAirportsService;
        public AirportDistanceMeasureService(ILogger<AirportDistanceMeasureService> logger, HttpClient httpClient, IGetAirportsService getAirportsService) : base(logger, httpClient)
        {
            _getAirportsService = getAirportsService;
        }
        public async Task<AirportDTO> GetAirportDistance(AirportIataCodesRequest airportIataCodesRequest, string baseAddress)
        {
            List<AirportDTO> airportDTO = new List<AirportDTO>();

            _logger.LogInformation($"GetAirportDistance request started. fromIataCode: {0}, toIataCode {1}" , airportIataCodesRequest.FromIataCode, airportIataCodesRequest.ToIataCode);

            var iataCodes = new List<string> { airportIataCodesRequest.FromIataCode, airportIataCodesRequest.ToIataCode };

            foreach (var iataCode in iataCodes)
            {
                var result = await _getAirportsService.GetAirports(iataCode, baseAddress);

                airportDTO.Add(result);
            }

            throw new NotImplementedException();
        }
    }
}
