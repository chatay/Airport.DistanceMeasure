using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Airport.DistanceMeasure.Application.Exceptions
{
    [Serializable()]
    public class AirportException: Exception
    {
        public AirportException()
        {

        }
        public AirportException(string message) : base(message) { }
        public AirportException(Exception message, Exception inner) : base(message.Message, inner) { }
        public AirportException(string message, Exception inner) : base(message, inner) { }
        public AirportException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    }
}
