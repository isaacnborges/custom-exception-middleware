using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CustomExceptionMiddleware.WebAppTest.Custom
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CustomExceptionMiddleware.WebAppTest.Custom", Version = "v1" });
            });

            services.AddScoped<IProductService, ProductService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CustomExceptionMiddleware.WebAppTest.Custom v1"));
            }

            app.UseCustomExceptionMiddleware(new CustomExceptionOptions
            {
                CustomErrorModel = new
                {
                    CustomValue = "ValueObject",
                    Success = false
                }
            });
            app.UseCustomExceptionMiddleware(options =>
            {
                options.CustomErrorModel = new
                {
                    CustomValue = "ValueAction",
                    Success = false
                };
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
