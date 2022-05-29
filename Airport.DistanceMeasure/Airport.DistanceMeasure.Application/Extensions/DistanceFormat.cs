using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.DistanceMeasure.Application.Extensions
{
    public static class DistanceFormat
    {
        public static string FormatDistance(this double distance)
        {
            return distance.FormatDistance("");
        }

        public static string FormatDistance(this double distance, string unitString)
        {
            return String.Format("{0:0.00} {1}", distance, unitString);
        }
    }
}
