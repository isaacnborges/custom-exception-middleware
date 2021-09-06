using CustomExceptionMiddleware.CustomExceptions;

namespace CustomExceptionMiddleware.WebAppTest
{
    public class InvalidStateException : DomainException
    {
        public InvalidStateException(string message) : base(message)
        { }
    }
}
