using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Airport.DistanceMeasure.Application.DTOs
{
    public class AirportIataCodesRequest
    {
        [JsonProperty(PropertyName ="from")]
        public string FromIataCode { get; set; }

        [JsonProperty(PropertyName = "to")]
        public string ToIataCode { get; set; }
    }
}
