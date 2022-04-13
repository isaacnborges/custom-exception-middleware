using System;
using System.Runtime.Serialization;

namespace CustomExceptionMiddleware.CustomExceptions
{
    [Serializable]
    public class UnauthorizedException : CustomException
    {
        public UnauthorizedException()
        { }

        public UnauthorizedException(string message) : base(message)
        { }

        public UnauthorizedException(string message, Exception innerException) : base(message, innerException)
        { }

        protected UnauthorizedException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }

        public UnauthorizedException(string message, string exceptionType) : base(message)
        {
            ExceptionType = exceptionType;
        }

        public UnauthorizedException(string message, string exceptionType, Exception innerException) : base(message, innerException)
        {
            ExceptionType = exceptionType;
        }
    }
}