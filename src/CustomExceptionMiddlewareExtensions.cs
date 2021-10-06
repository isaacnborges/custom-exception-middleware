using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace CustomExceptionMiddleware
{
    public static class CustomExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomExceptionMiddleware>();
        }

        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder app, CustomExceptionOptions options)
        {
            ValidateOptions(options);

            return app.UseMiddleware<CustomExceptionMiddleware>(Options.Create(options));
        }

        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder app, Action<CustomExceptionOptions> configureOptions)
        {
            CustomExceptionOptions options;
            using (var scope = app.ApplicationServices.CreateScope())
            {
                options = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<CustomExceptionOptions>>().Value;
                configureOptions.Invoke(options);
            }

            return app.UseMiddleware<CustomExceptionMiddleware>(Options.Create(options));
        }

        private static void ValidateOptions(CustomExceptionOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
        }
    }
}
