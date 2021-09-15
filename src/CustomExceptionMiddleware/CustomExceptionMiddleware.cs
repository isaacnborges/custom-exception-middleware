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

        private readonly JsonSerializerOptions _serializeOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        private const string UnexpectedError = "UNEXPECTED_ERROR";
        private const string ValidationErrors = "VALIDATION_ERRORS";

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
            LogException(httpContext, exception);

            var result = GetResultException(exception);

            await httpContext.Response.WriteAsync(result, Encoding.UTF8);
        }

        private string GetResultException(Exception exception)
        {
            var customErrorResponse = BuildCustomErrorResponse(exception);
            return JsonSerializer.Serialize(customErrorResponse, _serializeOptions);
        }

        private object BuildCustomErrorResponse(Exception exception)
        {
            if (_options.ViewStackTrace)
            {
                return new CustomErrorDetailResponse
                {
                    Type = exception.GetType().Name.Equals(nameof(Exception)) ? UnexpectedError : ValidationErrors,
                    Error = new CustomErrorDetail(exception.Message, exception.StackTrace)
                };
            }

            return new CustomErrorResponse
            {
                Type = exception.GetType().Name.Equals(nameof(Exception)) ? UnexpectedError : ValidationErrors,
                Error = new CustomError(exception.Message)
            };
        }

        private static void ConfigureResponseContext(HttpContext httpContext, HttpStatusCode statusCode)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode.GetIntValue();
        }

        private void LogException(HttpContext httpContext, Exception exception)
        {
            _logger.LogError(exception, $"Occurred an exception - TraceId: {httpContext.TraceIdentifier} - ExceptionType: {exception.GetType().Name} - Message: {exception.Message}");
        }
    }
}
