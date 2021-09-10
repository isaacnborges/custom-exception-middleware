using CustomExceptionMiddleware.WebAppTest;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace CustomExceptionMiddleware.Tests
{
    public class CustomExceptionMiddlewareTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private string _url = "/customer";

        public CustomExceptionMiddlewareTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory(DisplayName = "Should return Ok and get customers")]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(50)]
        public async Task GetAsync_GetCustomers_ShouldReturnOK(int count)
        {
            // Arrange
            _url += $"?count={count}";
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(_url);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var responseContent = await response.Content.ReadAsAsync<IEnumerable<Customer>>();
            responseContent.Should().NotBeNullOrEmpty();
            responseContent.Should().HaveCount(count);
        }

        [Fact(DisplayName = "Should return bad request and throw a domain exception")]
        public async Task GetAsync_ThrowDomainException_ShouldReturnBadRequest()
        {
            // Arrange
            _url += "/domain";
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(_url);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            var responseContent = await response.Content.ReadAsAsync<CustomErrorResponse>();
            responseContent.Should().NotBeNull();
            responseContent.ErrorMessage.Should().Be("Custom domain exception message");
        }

        [Fact(DisplayName = "Should return forbidden and throw a cannot access exception")]
        public async Task GetAsync_ThrowCannotAccessException_ShouldReturnForbidden()
        {
            // Arrange
            _url += "/cannot-access";
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(_url);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
            var responseContent = await response.Content.ReadAsAsync<CustomErrorResponse>();
            responseContent.Should().NotBeNull();
            responseContent.ErrorMessage.Should().Be("Custom cannot access exception message");
        }

        [Fact(DisplayName = "Should return not found and throw a not found exception")]
        public async Task GetAsync_ThrowNotFoundException_ShouldNotFound()
        {
            // Arrange
            _url += "/not-found";
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(_url);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
            var responseContent = await response.Content.ReadAsAsync<CustomErrorResponse>();
            responseContent.Should().NotBeNull();
            responseContent.ErrorMessage.Should().Be("Custom not found exception message");
        }

        [Fact(DisplayName = "Should return internal server error and throw an exception")]
        public async Task GetAsync_ThrowException_ShouldReturnInternalServerError()
        {
            // Arrange
            _url += "/exception";
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(_url);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
            var responseContent = await response.Content.ReadAsAsync<CustomErrorResponse>();
            responseContent.Should().NotBeNull();
            responseContent.ErrorMessage.Should().Be("Custom exception message");
        }
    }
}

