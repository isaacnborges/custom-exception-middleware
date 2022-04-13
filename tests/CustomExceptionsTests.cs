using CustomExceptionMiddleware.CustomExceptions;
using CustomExceptionMiddleware.WebAppTest;
using CustomExceptionMiddleware.WebAppTest.Custom;
using FluentAssertions;
using System;
using Xunit;

namespace CustomExceptionMiddleware.Tests
{
    public class CustomExceptionsTests
    {
        private readonly string _errorMessage = "Custom error message example";
        private readonly string _exceptionType = "NEWEXCEPTION_ERROR";

        #region CannotAccessException
        [Fact(DisplayName = "Should throw cannot access exception")]
        public void NewCannotAccessException_ThrowException_ShouldThrowCannotAccessException()
        {
            // Act
            Action action = () => throw new CannotAccessException();

            // Assert
            action.Should().Throw<CannotAccessException>();
        }

        [Fact(DisplayName = "Should throw cannot access exception with message")]
        public void NewCannotAccessException_ThrowException_ShouldThrowCannotAccessExceptionWithMessage()
        {
            // Act
            Action action = () => throw new CannotAccessException(_errorMessage);

            // Assert
            action.Should().Throw<CannotAccessException>().WithMessage(_errorMessage);
        }

        [Fact(DisplayName = "Should throw cannot access exception with message and inner exception")]
        public void NewCannotAccessException_ThrowException_ShouldThrowCannotAccessExceptionWithMessageAndInnerException()
        {
            // Act
            Action action = () => throw new CannotAccessException(_errorMessage, new CannotAccessException());

            // Assert
            action.Should().Throw<CannotAccessException>().WithMessage(_errorMessage).WithInnerException<CannotAccessException>();
        }

        [Fact(DisplayName = "Should throw cannot access exception with message and exception type")]
        public void NewCannotAccessException_ThrowException_ShouldThrowCannotAccessExceptionWithMessageAndExceptionType()
        {
            // Act
            Action action = () => throw new CannotAccessException(_errorMessage, _exceptionType);

            // Assert
            action.Should().Throw<CannotAccessException>().WithMessage(_errorMessage);
        }

        [Fact(DisplayName = "Should throw cannot access exception with message, exception type and inner exception")]
        public void NewCannotAccessException_ThrowException_ShouldThrowCannotAccessExceptionWithMessageAndExceptionTypeAndInnerException()
        {
            // Act
            Action action = () => throw new CannotAccessException(_errorMessage, _exceptionType, new CannotAccessException());

            // Assert
            action.Should().Throw<CannotAccessException>().WithMessage(_errorMessage).WithInnerException<CannotAccessException>();
        }
        #endregion

        #region NotFoundException
        [Fact(DisplayName = "Should throw not found exception")]
        public void NewNotFoundException_ThrowException_ShouldThrowNotFoundException()
        {
            // Act
            Action action = () => throw new NotFoundException();

            // Assert
            action.Should().Throw<NotFoundException>();
        }

        [Fact(DisplayName = "Should throw not found exception with message")]
        public void NewNotFoundException_ThrowException_ShouldThrowNotFoundExceptionWithMessage()
        {
            // Act
            Action action = () => throw new NotFoundException(_errorMessage);

            // Assert
            action.Should().Throw<NotFoundException>().WithMessage(_errorMessage);
        }

        [Fact(DisplayName = "Should throw not found exception with message and inner exception")]
        public void NewNotFoundException_ThrowException_ShouldThrowNotFoundExceptionWithMessageAndInnerException()
        {
            // Act
            Action action = () => throw new NotFoundException(_errorMessage, new NotFoundException());

            // Assert
            action.Should().Throw<NotFoundException>().WithMessage(_errorMessage).WithInnerException<NotFoundException>();
        }

        [Fact(DisplayName = "Should throw not found exception with message and exception type")]
        public void NewNotFoundException_ThrowException_ShouldThrowNotFoundExceptionWithMessageAndExceptionType()
        {
            // Act
            Action action = () => throw new NotFoundException(_errorMessage, _exceptionType);

            // Assert
            action.Should().Throw<NotFoundException>().WithMessage(_errorMessage);
        }

        [Fact(DisplayName = "Should throw not found exception with message, exception type and inner exception")]
        public void NewNotFoundException_ThrowException_ShouldThrowNotFoundExceptionWithMessageAndExceptionTypeAndInnerException()
        {
            // Act
            Action action = () => throw new NotFoundException(_errorMessage, _exceptionType, new NotFoundException());

            // Assert
            action.Should().Throw<NotFoundException>().WithMessage(_errorMessage).WithInnerException<NotFoundException>();
        }
        #endregion

        #region UnauthorizedException
        [Fact(DisplayName = "Should throw unauthorized exception")]
        public void NewUnauthorizedException_ThrowException_ShouldThrowUnauthorizedException()
        {
            // Act
            Action action = () => throw new UnauthorizedException();

            // Assert
            action.Should().Throw<UnauthorizedException>();
        }

        [Fact(DisplayName = "Should throw unauthorized exception with message")]
        public void NewUnauthorizedException_ThrowException_ShouldThrowUnauthorizedExceptionWithMessage()
        {
            // Act
            Action action = () => throw new UnauthorizedException(_errorMessage);

            // Assert
            action.Should().Throw<UnauthorizedException>().WithMessage(_errorMessage);
        }

        [Fact(DisplayName = "Should throw unauthorized exception with message and inner exception")]
        public void NewUnauthorizedException_ThrowException_ShouldThrowUnauthorizedExceptionWithMessageAndInnerException()
        {
            // Act
            Action action = () => throw new UnauthorizedException(_errorMessage, new UnauthorizedException());

            // Assert
            action.Should().Throw<UnauthorizedException>().WithMessage(_errorMessage).WithInnerException<UnauthorizedException>();
        }

        [Fact(DisplayName = "Should throw unauthorized exception with message and exception type")]
        public void NewUnauthorizedException_ThrowException_ShouldThrowUnauthorizedExceptionWithMessageAndExceptionType()
        {
            // Act
            Action action = () => throw new UnauthorizedException(_errorMessage, _exceptionType);

            // Assert
            action.Should().Throw<UnauthorizedException>().WithMessage(_errorMessage);
        }

        [Fact(DisplayName = "Should throw unauthorized exception with message, exception type and inner exception")]
        public void NewUnauthorizedException_ThrowException_ShouldThrowUnauthorizedExceptionWithMessageAndExceptionTypeAndInnerException()
        {
            // Act
            Action action = () => throw new UnauthorizedException(_errorMessage, _exceptionType, new UnauthorizedException());

            // Assert
            action.Should().Throw<UnauthorizedException>().WithMessage(_errorMessage).WithInnerException<UnauthorizedException>();
        }
        #endregion

        #region DomainException/InvalidStateException
        [Fact(DisplayName = "Should throw invalid state exception")]
        public void NewInvalidStateException_ThrowException_ShouldThrowInvalidStateException()
        {
            // Act
            Action action = () => throw new InvalidStateException();

            // Assert
            action.Should().Throw<InvalidStateException>();
        }

        [Fact(DisplayName = "Should throw invalid state exception with message")]
        public void NewInvalidStateException_ThrowException_ShouldThrowInvalidStateExceptionWithMessage()
        {
            // Act
            Action action = () => throw new InvalidStateException(_errorMessage);

            // Assert
            action.Should().Throw<InvalidStateException>().WithMessage(_errorMessage);
        }

        [Fact(DisplayName = "Should throw invalid state exception with message and inner exception")]
        public void NewInvalidStateException_ThrowException_ShouldThrowInvalidStateExceptionWithMessageAndInnerException()
        {
            // Act
            Action action = () => throw new InvalidStateException(_errorMessage, new InvalidStateException());

            // Assert
            action.Should().Throw<InvalidStateException>().WithMessage(_errorMessage).WithInnerException<InvalidStateException>();
        }

        [Fact(DisplayName = "Should throw invalid state exception with message and exception type")]
        public void NewInvalidStateException_ThrowException_ShouldThrowInvalidStateExceptionWithMessageAndExceptionType()
        {
            // Act
            Action action = () => throw new InvalidStateException(_errorMessage, _exceptionType);

            // Assert
            action.Should().Throw<InvalidStateException>().WithMessage(_errorMessage);
        }

        [Fact(DisplayName = "Should throw not found exception with message, exception type and inner exception")]
        public void NewInvalidStateException_ThrowException_ShouldThrowInvalidStateExceptionWithMessageAndExceptionTypeAndInnerException()
        {
            // Act
            Action action = () => throw new InvalidStateException(_errorMessage, _exceptionType, new InvalidStateException());

            // Assert
            action.Should().Throw<InvalidStateException>().WithMessage(_errorMessage).WithInnerException<InvalidStateException>();
        }
        #endregion

        #region DomainException/CustomDomainException
        [Fact(DisplayName = "Should throw custom domain exception")]
        public void NewCustomDomainException_ThrowException_ShouldThrowCustomDomainException()
        {
            // Act
            Action action = () => throw new CustomDomainException();

            // Assert
            action.Should().Throw<CustomDomainException>();
        }

        [Fact(DisplayName = "Should throw custom domain exception with message")]
        public void NewCustomDomainException_ThrowException_ShouldThrowCustomDomainExceptionWithMessage()
        {
            // Act
            Action action = () => throw new CustomDomainException(_errorMessage);

            // Assert
            action.Should().Throw<CustomDomainException>().WithMessage(_errorMessage);
        }

        [Fact(DisplayName = "Should throw custom domain exception with message and inner exception")]
        public void NewCustomDomainException_ThrowException_ShouldThrowCustomDomainExceptionWithMessageAndInnerException()
        {
            // Act
            Action action = () => throw new CustomDomainException(_errorMessage, new CustomDomainException());

            // Assert
            action.Should().Throw<CustomDomainException>().WithMessage(_errorMessage).WithInnerException<CustomDomainException>();
        }

        [Fact(DisplayName = "Should throw custom domain exception with message and exception type")]
        public void NewCustomDomainException_ThrowException_ShouldThrowCustomDomainExceptionWithMessageAndExceptionType()
        {
            // Act
            Action action = () => throw new CustomDomainException(_errorMessage, _exceptionType);

            // Assert
            action.Should().Throw<CustomDomainException>().WithMessage(_errorMessage);
        }

        [Fact(DisplayName = "Should throw not found exception with message, exception type and inner exception")]
        public void NewCustomDomainException_ThrowException_ShouldThrowCustomDomainExceptionWithMessageAndExceptionTypeAndInnerException()
        {
            // Act
            Action action = () => throw new CustomDomainException(_errorMessage, _exceptionType, new CustomDomainException());

            // Assert
            action.Should().Throw<CustomDomainException>().WithMessage(_errorMessage).WithInnerException<CustomDomainException>();
        }
        #endregion
    }
}
