using CustomExceptionMiddleware.CustomExceptions;
using System;
using System.Runtime.Serialization;

namespace CustomExceptionMiddleware.WebAppTest.Custom
{
    [Serializable]
    public class CustomDomainException : DomainException
    {
        public CustomDomainException(string message) : base(message)
        { }

        protected CustomDomainException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
