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
			return (!string.IsNullOrEmpty(iataCode) && iataCode.Length == 3 && iataCode.All(Char.IsLetter));
		}
	}
}
