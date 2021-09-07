using System;

namespace CustomExceptionMiddleware.CustomExceptions
{
    #pragma warning disable S3925 // "ISerializable" should be implemented correctly
    public abstract class DomainException : Exception
    #pragma warning restore S3925 // "ISerializable" should be implemented correctly
    {
        protected DomainException(string message) : base(message)
        { }
    }
}