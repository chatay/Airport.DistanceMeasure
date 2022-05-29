using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.DistanceMeasure.Application.Constants
{
    public class ValidationMessages
    {
        public static string IataCodeIsEmpty = "Two IATA code are required!";
        public static string IataCodeLengthNotValid = "IATA code must be 3 letters!";
        public static string DestinyIataCodeNotValid = "Destiny IATA code is not valid!";
        public static string FromIataCodeNotValid = "From IATA code is not valid!";
        public static string FromAndDestinyEqualError = "From IATA code should not be equal to destination IATA code!";
    }
}
