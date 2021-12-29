using System;
using System.Runtime.Serialization;

namespace CustomExceptionMiddleware.CustomExceptions
{
    [Serializable]
    public abstract class CustomException : Exception
    {
        public string ExceptionType { get; protected set; }

        protected CustomException()
        { }

        protected CustomException(string message) : base(message)
        { }

        protected CustomException(string message, Exception innerException) : base(message, innerException)
        { }

        protected CustomException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}