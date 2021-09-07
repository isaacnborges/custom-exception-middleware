using System;

namespace CustomExceptionMiddleware.CustomExceptions
{
    #pragma warning disable S3925 // "ISerializable" should be implemented correctly
    public class CannotAccessException : Exception
    #pragma warning restore S3925 // "ISerializable" should be implemented correctly
    {
        public CannotAccessException(string message) : base(message)
        { }
    }
}