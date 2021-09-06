using System;

namespace CustomExceptionMiddleware.CustomExceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        { }
    }
}

