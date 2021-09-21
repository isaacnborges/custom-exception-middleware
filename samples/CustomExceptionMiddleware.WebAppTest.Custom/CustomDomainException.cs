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

        protected CustomDomainException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}
