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
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Airport.DistanceMeasure.Infrastructure.Shared.Services
{
    public class GenericRequestAsyncService : BaseService<GenericRequestAsyncService>, IDisposable, IGetAirportsService
    {
        public GenericRequestAsyncService(ILogger<GenericRequestAsyncService> logger, HttpClient httpClient) : base(logger, httpClient)
        {
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }

        public async Task<AirportDTO> GetAirports(string iataCode, string baseAddress)
        {
            AirportDTO airportDTO = null;
            try
            {
                airportDTO = await GetAsync(HttpMethod.Get, baseAddress, iataCode.ToUpper());

                return airportDTO;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }

        }
        private async Task<AirportDTO> GetAsync(HttpMethod httpMethod, string url, string iataCode)
        {
            using var response = await _httpClient.GetAsync(url + iataCode);

            var content = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new HttpException("HttpStatusCode.NotFound");
            }

            if (!response.IsSuccessStatusCode)
            {
                var responseMessageBuilder = new StringBuilder();
                responseMessageBuilder.Append("Airport Request Error:");
                responseMessageBuilder.AppendFormat("\n Got status {0}: ", response.StatusCode);
                responseMessageBuilder.AppendFormat("\n Request {0} {1}: ", httpMethod.Method, url);
                responseMessageBuilder.AppendFormat("\n Response Headers: ");

                foreach (var header in response.Headers)
                {
                    responseMessageBuilder.AppendFormat("\n    {0}: \t{1}", header.Key, string.Join(" ,", header.Value));
                }
                responseMessageBuilder.AppendFormat("\n- Response Content: {0}", content);
                throw new InvalidOperationException(responseMessageBuilder.ToString());
            }
            return JsonConvert.DeserializeObject<AirportDTO>(content);
        }
    }
}
