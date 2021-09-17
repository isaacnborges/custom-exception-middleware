using CustomExceptionMiddleware.CustomExceptions;
using System;
using System.Runtime.Serialization;

namespace CustomExceptionMiddleware.WebAppTest.Custom
{
    [Serializable]
    public class ProductCustomException : DomainException
    {
        public ProductCustomException(string message) : base(message)
        { }

        protected ProductCustomException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
