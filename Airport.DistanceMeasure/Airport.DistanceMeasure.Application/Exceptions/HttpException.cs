using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.DistanceMeasure.Application.Exceptions
{
    public class HttpException : Exception
    {
        public HttpException():base()
        {

        }
        public HttpException(string message) :base(message)
        {

        }
        public HttpException(string message, Exception innerException):base(message, innerException)
        {

        }
    }
}
