using System;
using System.Runtime.Serialization;

namespace CustomExceptionMiddleware.CustomExceptions
{
    [Serializable]
    public class NotFoundException : CustomException
    {
        public NotFoundException()
        { }

        public NotFoundException(string message) : base(message)
        { }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        { }

        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }

        public NotFoundException(string message, string exceptionType) : base(message)
        {
            ExceptionType = exceptionType;
        }

        public NotFoundException(string message, string exceptionType, Exception innerException) : base(message, innerException)
        {
            ExceptionType = exceptionType;
        }
    }
}