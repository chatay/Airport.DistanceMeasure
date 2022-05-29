using Airport.DistanceMeasure.Application.DTOs;
using Airport.DistanceMeasure.Application.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Airport.DistanceMeasure.Infrastructure.Shared.Services
{
    public class AirportDistanceMeasureService : BaseService<AirportDistanceMeasureService>, IAirportDistanceMeasureService
    {
        public AirportDistanceMeasureService(ILogger<AirportDistanceMeasureService> logger, HttpClient httpClient) : base(logger, httpClient)
        {
        }
        public Task<AirportDistanceDTO> GetAirportDistance(AirportIataCodesRequest airportIataCodesRequest)
        {
            _logger.LogInformation($"GetAirportDistance request started. fromIataCode: {0}, toIataCode {1}" , airportIataCodesRequest.FromIataCode, airportIataCodesRequest.ToIataCode);
            throw new NotImplementedException();
        }
    }
}
