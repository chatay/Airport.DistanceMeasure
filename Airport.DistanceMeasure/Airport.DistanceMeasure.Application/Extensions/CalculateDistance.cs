using Airport.DistanceMeasure.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.DistanceMeasure.Application.Extensions
{
    public static class CalculateDistance
    {
        public static string CalculateDistanceBetweenTwoAirports(this List<AirportDTO> airportDTO)
        {
            var d1 = airportDTO[0].Location.Lat * (Math.PI / 180.0);
            var num1 = airportDTO[0].Location.Lon * (Math.PI / 180.0);
            var d2 = airportDTO[1].Location.Lat * (Math.PI / 180.0);
            var num2 = airportDTO[1].Location.Lon * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) +
                     Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);

            var result = 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));

            return result.FormatDistance("km");
        }
    }
}
