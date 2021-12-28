using CustomExceptionMiddleware.CustomExceptions;
using System;
using System.Runtime.Serialization;

namespace CustomExceptionMiddleware.WebAppTest.Custom
{
    [Serializable]
    public class CustomDomainException : DomainException
    {
        public CustomDomainException()
        { }

        public CustomDomainException(string message) : base(message)
        { }

        public CustomDomainException(string message, Exception innerException) : base(message, innerException)
        { }

        public CustomDomainException(string message, string exceptionType) : base(message)
        {
            ExceptionType = exceptionType;
        }

        public CustomDomainException(string message, string exceptionType, Exception innerException) : base(message, innerException)
        {
            ExceptionType = exceptionType;
        }

        protected CustomDomainException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}
