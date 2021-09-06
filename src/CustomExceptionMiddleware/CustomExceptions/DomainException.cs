using System;

namespace CustomExceptionMiddleware.CustomExceptions
{
    public abstract class DomainException : Exception
    {
        protected DomainException(string message) : base(message)
        { }
    }
}