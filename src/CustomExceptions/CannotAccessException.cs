using System;
using System.Runtime.Serialization;

namespace CustomExceptionMiddleware.CustomExceptions
{
    [Serializable]
    public class CannotAccessException : Exception
    {
        public CannotAccessException(string message) : base(message)
        { }

        protected CannotAccessException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}