using CustomExceptionMiddleware.WebAppTest.Custom;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace CustomExceptionMiddleware.Tests
{
    public class CustomExceptionMiddlewareWebAppCustomTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private string _url = "/product";
        private const string ValidationErrors = "VALIDATION_ERRORS";

        public CustomExceptionMiddlewareWebAppCustomTests(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Theory(DisplayName = "Should return Ok and get products")]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(50)]
        public async Task GetAsync_GetProducts_ShouldReturnOK(int productsCount)
        {
            // Arrange
            _url += $"?count={productsCount}";

            // Act
            var response = await _client.GetAsync(_url);

            // Assert
            response.Should().Be200Ok();
            var responseContent = await response.Content.ReadAsAsync<IEnumerable<Product>>();
            responseContent.Should().NotBeNullOrEmpty();
            responseContent.Should().HaveCount(productsCount);
        }

        [Fact(DisplayName = "Should return bad request and throw a domain exception")]
        public async Task GetAsync_ThrowDomainException_ShouldReturnBadRequest()
        {
            // Arrange
            _url += "/domain";

            // Act
            var response = await _client.GetAsync(_url);

            // Assert
            response.Should().Be400BadRequest();
            var responseContent = await response.Content.ReadAsAsync<CustomErrorDetailResponse>();
            responseContent.Type.Should().Be(ValidationErrors);
            responseContent.Error.Detail.Should().NotBeNullOrEmpty();
            responseContent.Error.Msg.Should().Be("Custom domain exception message");
        }

        [Fact(DisplayName = "Should return Ok and get customers from domain url")]
        public async Task GetAsyncDomain_GetCustomers_ShouldReturnOK()
        {
            // Arrange
            _url += $"/domain?returnProduct={true}";

            // Act
            var response = await _client.GetAsync(_url);

            // Assert
            response.Should().Be200Ok();
            var responseContent = await response.Content.ReadAsAsync<IEnumerable<CustomErrorDetailResponse>>();
            responseContent.Should().NotBeNullOrEmpty();
        }
    }
}
