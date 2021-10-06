using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CustomExceptionMiddleware.Tests
{
    public class CustomExceptionMiddlewareExtensionsTests
    {
        [Fact(DisplayName = "Should throw argument null exception when create null custom exception options")]
        public async Task UseCustomExceptionMiddleware_CreateNullOptions_ShouldThrowArgumentNullException()
        {
            // Act
            Func<Task> act = async () => 
            {
                await new HostBuilder()
                                .ConfigureWebHost(webBuilder =>
                                {
                                    webBuilder
                                        .UseTestServer()
                                        .ConfigureServices(services => { })
                                        .Configure(app =>
                                        {
                                            CustomExceptionOptions customExceptionOptions = null;
                                            app.UseCustomExceptionMiddleware(customExceptionOptions);
                                        });
                                })
                                .StartAsync();
            };

            // Assert
            await act.Should().ThrowAsync<ArgumentNullException>();
        }
    }
}
