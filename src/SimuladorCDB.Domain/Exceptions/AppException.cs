﻿using System.Globalization;
using System.Runtime.Serialization;

namespace SimuladorCDB.Domain.Exceptions
{
    [Serializable]
    public class AppException : Exception
    {
        public AppException(string message) : base(message)
        {

        }

        public AppException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected AppException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
