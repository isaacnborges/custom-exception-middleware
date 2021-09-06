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
            ValidateAppBuilder(app);

            return app.UseMiddleware<CustomExceptionMiddleware>();
        }

        public static IApplicationBuilder UseCustomExceptionMiddleware(
            this IApplicationBuilder app,
            CustomExceptionOptions options)
        {
            ValidateAppBuilder(app);
            ValidateOptions(options);

            return app.UseMiddleware<CustomExceptionMiddleware>(Options.Create(options));
        }

        public static IApplicationBuilder UseCustomExceptionMiddleware(
            this IApplicationBuilder app,
            Action<CustomExceptionOptions> configureOptions)
        {
            ValidateAppBuilder(app);
            ValidateActionOptions(configureOptions);

            CustomExceptionOptions options;
            using (var scope = app.ApplicationServices.CreateScope())
            {
                options = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<CustomExceptionOptions>>().Value;
                configureOptions.Invoke(options);
            }

            return app.UseMiddleware<CustomExceptionMiddleware>(Options.Create(options));
        }

        private static void ValidateAppBuilder(IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
        }

        private static void ValidateOptions(CustomExceptionOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
        }

        private static void ValidateActionOptions(Action<CustomExceptionOptions> configureOptions)
        {
            if (configureOptions == null)
            {
                throw new ArgumentNullException(nameof(configureOptions));
            }
        }
    }
}

