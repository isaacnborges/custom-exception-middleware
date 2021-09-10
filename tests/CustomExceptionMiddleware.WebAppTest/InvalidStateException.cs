using CustomExceptionMiddleware.CustomExceptions;
using System;
using System.Runtime.Serialization;

namespace CustomExceptionMiddleware.WebAppTest
{
    [Serializable]
    public class InvalidStateException : DomainException
    {
        public InvalidStateException(string message) : base(message)
        { }

        protected InvalidStateException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
