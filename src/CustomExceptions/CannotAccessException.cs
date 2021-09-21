using System;
using System.Runtime.Serialization;

namespace CustomExceptionMiddleware.CustomExceptions
{
    [Serializable]
    public class CannotAccessException : Exception
    {
        public CannotAccessException()
        { }

        public CannotAccessException(string message) : base(message)
        { }

        public CannotAccessException(string message, Exception innerException) : base(message, innerException)
        { }

        protected CannotAccessException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}