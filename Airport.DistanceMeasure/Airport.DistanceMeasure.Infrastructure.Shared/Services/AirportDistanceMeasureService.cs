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
        public Task<AirportDistanceDTO> GetAirportDistance(string fromIataCode, string toIataCode)
        {
            _logger.LogInformation("");
            throw new NotImplementedException();
        }
    }
}
