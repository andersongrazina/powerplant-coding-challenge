using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace PowerPlant.Api.Configurations
{
    public static class SwaggerSetup
    {
        public static void AddSwaggerSetup(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("powerplant", new OpenApiInfo
                {
                    Version = "1.0",
                    Title = "PowerPlant API",
                    Description = "This API is part of a code challenge, and the objective is to calculate how much power each powerplants need to produce for reach load information given.",
                    Contact = new OpenApiContact { Name = "Anderson Grazina", Email = "andersongrazina@gmail.com", Url = new Uri("https://www.linkedin.com/in/andersongrazina/") },
                    License = new OpenApiLicense { Name = "GNU 3.0", Url = new Uri("https://github.com/philipgpencal/powerplant-coding-challenge/blob/master/LICENSE") }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                s.IncludeXmlComments(xmlPath);
            });
        }

        public static void ConfigureSwaggerSetup(this IApplicationBuilder app)
        {
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "docs/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(s =>
            {
                s.RoutePrefix = string.Empty;
                s.DocumentTitle = "PowerPlant API";
                s.InjectStylesheet("./swagger/css/swagger-custom.css");
                s.InjectJavascript("./swagger/js/swagger-custom.js");
                s.SwaggerEndpoint("/docs/powerplant/swagger.json", "PowerPlant API 1.0");
            });
        }
    }
}
