using System;
using System.Runtime.Serialization;

namespace WeatherService.Controllers
{
    [Serializable]
    internal class httpRequestException : Exception
    {
        public httpRequestException()
        {
        }

        public httpRequestException(string message) : base(message)
        {
        }

        public httpRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected httpRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}