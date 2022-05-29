using Airport.DistanceMeasure.Application.DTOs;
using Airport.DistanceMeasure.Application.Exceptions;
using Airport.DistanceMeasure.Application.Extensions;
using Airport.DistanceMeasure.Application.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
        public async Task<AirportDistanceDTO> GetAirportDistance(AirportIataCodesRequest airportIataCodesRequest, string baseAddress)
        {
            try
            {
                List<AirportDTO> airportDTO = new List<AirportDTO>();

                _logger.LogInformation($"GetAirportDistance request started. fromIataCode: {0}, toIataCode {1}", airportIataCodesRequest.FromIataCode, airportIataCodesRequest.ToIataCode);

                var iataCodes = new List<string> { airportIataCodesRequest.FromIataCode, airportIataCodesRequest.ToIataCode };

                #region GetAirportInformation

                await GetAirportInformation(baseAddress, airportDTO, iataCodes);

                #endregion

                _logger.LogInformation($"GetAirportDistance request finished. fromIataCode: {0}", JsonConvert.SerializeObject(airportDTO));

                #region CalculateDistanceBetweenAirports

                var distanceResult = CalculateDistanceBetweenAirports(airportDTO);

                #endregion

                return new AirportDistanceDTO { Distance = distanceResult };
            }
            catch (Exception ex)
            {
                throw new AirportException(ex.Message, ex.InnerException);
            }
        }

        private async Task GetAirportInformation(string baseAddress, List<AirportDTO> airportDTO, List<string> iataCodes)
        {
            foreach (var iataCode in iataCodes)
            {
                var result = await _getAirportsService.GetAirports(iataCode, baseAddress);

                airportDTO.Add(result);
            }
        }

        private static string CalculateDistanceBetweenAirports(List<AirportDTO> airportDTO)
        {
            if (airportDTO == null) throw new AirportException("_getAirportsService could not fetch data!");

            return airportDTO.CalculateDistanceBetweenTwoAirports();
        }
    }
}
