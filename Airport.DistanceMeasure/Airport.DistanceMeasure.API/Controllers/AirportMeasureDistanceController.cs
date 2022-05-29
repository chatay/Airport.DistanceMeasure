using Airport.DistanceMeasure.Application.DTOs;
using Airport.DistanceMeasure.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        public AirportMeasureDistanceController(IAirportDistanceMeasureService airportDistanceMeasure)
        {
            _airportDistanceMeasure = airportDistanceMeasure;
        }

        [HttpGet(Name ="GetDistanceBetweenAirports")]
        public async Task<IActionResult> MeasureDistanceBetweenAirports([FromQuery] AirportIataCodesRequest airportIataCodesRequest)
        {
            await _airportDistanceMeasure.GetAirportDistance(airportIataCodesRequest);
            return Ok();
        }
    }
}
