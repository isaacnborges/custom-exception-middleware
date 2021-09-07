using CustomExceptionMiddleware.CustomExceptions;

namespace CustomExceptionMiddleware.WebAppTest
{
    #pragma warning disable S3925 // "ISerializable" should be implemented correctly
    public class InvalidStateException : DomainException
    #pragma warning restore S3925 // "ISerializable" should be implemented correctly
    {
        public InvalidStateException(string message) : base(message)
        { }
    }
}
