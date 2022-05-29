using Airport.DistanceMeasure.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.DistanceMeasure.Application.Interfaces
{
    public interface IAirportDistanceMeasureService
    {
        Task<AirportDistanceDTO> GetAirportDistance(AirportIataCodesRequest airportIataCodesRequest, string baseAddress);
    }
}
