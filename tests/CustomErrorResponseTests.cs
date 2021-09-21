using FluentAssertions;
using Xunit;

namespace CustomExceptionMiddleware.Tests
{
    public class CustomErrorResponseTests
    {
        [Fact(DisplayName = "Should create custom error response with constructor")]
        public void NewCustomErrorResponse_ValidObject_ShouldCreateObjectWithContructor()
        {
            // Arrange
            var type = "testType";

            // Act
            var response = new CustomErrorResponse(type, new CustomError());

            // Assert
            response.Type.Should().Be(type);
            response.Error.Should().NotBeNull();
            response.Error.Msg.Should().BeNull();
        }

        [Fact(DisplayName = "Should create custom error response")]
        public void NewCustomErrorResponse_ValidObject_ShouldCreateObject()
        {
            // Arrange
            var type = "testType";
            var customError = new CustomError();

            // Act
            var response = new CustomErrorResponse
            {
                Type = type,
                Error = customError
            };

            // Assert
            response.Type.Should().Be(type);
            response.Error.Should().NotBeNull();
            response.Error.Msg.Should().BeNull();
        }

        [Fact(DisplayName = "Should create custom error with constructor")]
        public void NewCustomError_ValidObject_ShouldCreateObjectWithContructor()
        {
            // Arrange
            var msg = "new test error messate";

            // Act
            var response = new CustomError(msg);

            // Assert
            response.Msg.Should().Be(msg);
        }

        [Fact(DisplayName = "Should create custom error response")]
        public void NewCustomError_ValidObject_ShouldCreateObject()
        {
            // Arrange
            var msg = "new test error message";

            // Act
            var response = new CustomError
            {
                Msg = msg
            };

            // Assert
            response.Msg.Should().Be(msg);
        }

        [Fact(DisplayName = "Should create custom error detail response with constructor")]
        public void NewCustomErrorDetailResponse_ValidObject_ShouldCreateObjectWithContructor()
        {
            // Arrange
            var type = "testType";

            // Act
            var response = new CustomErrorDetailResponse(type, new CustomErrorDetail());

            // Assert
            response.Type.Should().Be(type);
            response.Error.Should().NotBeNull();
            response.Error.Msg.Should().BeNull();
            response.Error.Detail.Should().BeNull();
        }

        [Fact(DisplayName = "Should create custom error detail response")]
        public void NewCustomErrorDetailResponse_ValidObject_ShouldCreateObject()
        {
            // Arrange
            var type = "testType";
            var customError = new CustomErrorDetail();

            // Act
            var response = new CustomErrorDetailResponse
            {
                Type = type,
                Error = customError
            };

            // Assert
            response.Type.Should().Be(type);
            response.Error.Should().NotBeNull();
            response.Error.Msg.Should().BeNull();
            response.Error.Detail.Should().BeNull();
        }

        [Fact(DisplayName = "Should create custom error with constructor")]
        public void NewCustomErrorDetail_ValidObject_ShouldCreateObjectWithContructor()
        {
            // Arrange
            var msg = "new test error message";
            var detail = "detail message";

            // Act
            var response = new CustomErrorDetail(msg, detail);

            // Assert
            response.Msg.Should().Be(msg);
            response.Detail.Should().Be(detail);
        }

        [Fact(DisplayName = "Should create custom error response")]
        public void NewCustomErrorDetail_ValidObject_ShouldCreateObject()
        {
            // Arrange
            var msg = "new test error messate";
            var detail = "detail message";

            // Act
            var response = new CustomErrorDetail
            {
                Msg = msg,
                Detail = detail
            };

            // Assert
            response.Msg.Should().Be(msg);
            response.Detail.Should().Be(detail);
        }
    }
}
