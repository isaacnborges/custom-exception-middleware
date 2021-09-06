using CustomExceptionMiddleware.CustomExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CustomExceptionMiddleware
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionMiddleware> _logger;
        private readonly CustomExceptionOptions _options;

        public CustomExceptionMiddleware(
            RequestDelegate next,
            IOptions<CustomExceptionOptions> options,
            ILogger<CustomExceptionMiddleware> logger)
        {
            _next = next;
            _options = options.Value;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (DomainException ex)
            {
                await HandleDomainException(httpContext, ex);
            }
            catch (CannotAccessException ex)
            {
                await HandleCannotAccessException(httpContext, ex);
            }
            catch (NotFoundException ex)
            {
                await HandleNotFoundException(httpContext, ex);
            }
            catch (Exception ex)
            {
                await HandleInternalServerErrorException(httpContext, ex);
            }
        }

        private async Task HandleDomainException(HttpContext httpContext, DomainException exception)
        {
            await HandleException(httpContext, exception, HttpStatusCode.BadRequest);
        }

        private async Task HandleCannotAccessException(HttpContext httpContext, CannotAccessException exception)
        {
            await HandleException(httpContext, exception, HttpStatusCode.Forbidden);
        }

        private async Task HandleNotFoundException(HttpContext httpContext, NotFoundException exception)
        {
            await HandleException(httpContext, exception, HttpStatusCode.NotFound);
        }

        private async Task HandleInternalServerErrorException(HttpContext httpContext, Exception exception)
        {
            await HandleException(httpContext, exception, HttpStatusCode.InternalServerError);
        }

        private async Task HandleException(HttpContext httpContext, Exception exception, HttpStatusCode statusCode)
        {
            ConfigureResponseContext(httpContext, statusCode);
            LogException(httpContext, exception.GetType().Name, exception.Message);

            var result = GetResultException(exception);

            await httpContext.Response.WriteAsync(result, Encoding.UTF8);
        }

        private string GetResultException(Exception exception)
        {
            string result;
            if (_options.CustomErrorModel == null)
                result = JsonSerializer.Serialize(new CustomErrorResponse(exception.Message));
            else
            {
                dynamic errorModel = _options.CustomErrorModel.ToExpandoObject();
                errorModel.ErrorMessage = exception.Message;
                result = JsonSerializer.Serialize(errorModel);
            }

            return result;
        }

        private void ConfigureResponseContext(HttpContext httpContext, HttpStatusCode statusCode)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode.GetIntValue();
        }

        private void LogException(HttpContext httpContext, string exceptionName, string message)
        {
            var request = httpContext.Request;
            _logger.LogInformation($"Url exception: {request.Scheme}://{request.Host}{request.Path}{request.QueryString}");
            _logger.LogError($"Occurred an exception - ExceptionType: {exceptionName} - Message: {message}");
        }
    }
}

