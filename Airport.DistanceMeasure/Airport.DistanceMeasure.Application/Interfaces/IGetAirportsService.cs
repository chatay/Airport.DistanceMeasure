using Airport.DistanceMeasure.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.DistanceMeasure.Application.Interfaces
{
    public interface IGetAirportsService
    {
        Task<AirportDTO> GetAirports(string iataCodes, string uri);
    }
}
