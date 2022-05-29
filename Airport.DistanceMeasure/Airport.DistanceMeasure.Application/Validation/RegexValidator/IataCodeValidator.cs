using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Airport.DistanceMeasure.Application.Validation.RegexValidator
{
	public class IataCodeValidator
	{
		public static bool IsValid(string iataCode)
		{
			return new Regex("^[A-Z]{3}$").IsMatch(iataCode);
		}
	}
}
