using System;
using System.Runtime.Serialization;

namespace CustomExceptionMiddleware.CustomExceptions
{
    [Serializable]
    public abstract class DomainException : CustomException
    {
        protected DomainException()
        { }

        protected DomainException(string message) : base(message)
        { }

        protected DomainException(string message, Exception innerException) : base(message, innerException)
        { }

        protected DomainException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }

        protected DomainException(string message, string exceptionType) : base(message)
        {
            ExceptionType = exceptionType;
        }

        protected DomainException(string message, string exceptionType, Exception innerException) : base(message, innerException)
        {
            ExceptionType = exceptionType;
        }

        protected DomainException(SerializationInfo info, string exceptionType, StreamingContext context) : base(info, context)
        {
            ExceptionType = exceptionType;
        }
    }
}