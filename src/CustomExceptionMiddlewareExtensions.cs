using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace CustomExceptionMiddleware
{
    /// <summary>
    /// Extension methods to add custom exception handling to an HTTP application pipeline.
    /// </summary>
    public static class CustomExceptionMiddlewareExtensions
    {
        /// <summary>
        /// Adds the <see cref="CustomExceptionMiddleware"/> to the specified <see cref="IApplicationBuilder"/>, which enables handling exceptions capabilities.
        /// </summary>
        /// <param name="app">The Microsoft.AspNetCore.Builder.IApplicationBuilder to add the middleware.</param>
        /// <returns>A reference to app after the operation has completed.</returns>
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomExceptionMiddleware>();
        }

        /// <summary>
        /// Adds the <see cref="CustomExceptionMiddleware"/> to the specified <see cref="IApplicationBuilder"/>, which enables handling exceptions capabilities.
        /// </summary>
        /// <param name="app">The Microsoft.AspNetCore.Builder.IApplicationBuilder to add the middleware.</param>
        /// <param name="options">An options to configure some specifics behaviors</param>
        /// <returns></returns>
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder app, CustomExceptionOptions options)
        {
            ValidateOptions(options);

            return app.UseMiddleware<CustomExceptionMiddleware>(Options.Create(options));
        }

        /// <summary>
        /// Adds the <see cref="CustomExceptionMiddleware"/> to the specified <see cref="IApplicationBuilder"/>, which enables handling exceptions capabilities.
        /// </summary>
        /// <param name="app">The Microsoft.AspNetCore.Builder.IApplicationBuilder to add the middleware.</param>
        /// <param name="configureOptions">An System.Action to configure the provided CustomExceptionOptions to configure some specifics behaviors</param>
        /// <returns></returns>
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
