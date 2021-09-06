using System;

namespace CustomExceptionMiddleware.CustomExceptions
{
    public class CannotAccessException : Exception
    {
        public CannotAccessException(string message) : base(message)
        { }
    }
}