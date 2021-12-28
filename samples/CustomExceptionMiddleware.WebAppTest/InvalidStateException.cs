using CustomExceptionMiddleware.CustomExceptions;
using System;
using System.Runtime.Serialization;

namespace CustomExceptionMiddleware.WebAppTest
{
    [Serializable]
    public class InvalidStateException : DomainException
    {
        public InvalidStateException()
        { }

        public InvalidStateException(string message) : base(message)
        { }

        public InvalidStateException(string message, Exception innerException) : base(message, innerException)
        { }

        public InvalidStateException(string message, string exceptionType) : base(message)
        {
            ExceptionType = exceptionType;
        }

        public InvalidStateException(string message, string exceptionType, Exception innerException) : base(message, innerException)
        {
            ExceptionType = exceptionType;
        }

        protected InvalidStateException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}
