using Airport.DistanceMeasure.Application.DTOs;
using Airport.DistanceMeasure.Application.Interfaces;
using Airport.DistanceMeasure.Application.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.DistanceMeasure.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AirportMeasureDistanceController : ControllerBase
    {
        private readonly IAirportDistanceMeasureService _airportDistanceMeasure;
        private readonly AirportConfigurations _configuration;
        public AirportMeasureDistanceController(IAirportDistanceMeasureService airportDistanceMeasure, IOptions<AirportConfigurations> configuration)
        {
            _airportDistanceMeasure = airportDistanceMeasure;
            _configuration = configuration.Value;
        }

        [HttpGet(Name ="GetDistanceBetweenAirports")]
        public async Task<AirportDistanceDTO> MeasureDistanceBetweenAirports([FromQuery] AirportIataCodesRequest airportIataCodesRequest)
        {
            return await _airportDistanceMeasure.GetAirportDistance(airportIataCodesRequest, _configuration.BaseAddress.AbsoluteUri);
        }
    }
}
