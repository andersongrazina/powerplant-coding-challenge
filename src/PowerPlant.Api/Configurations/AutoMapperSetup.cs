using Microsoft.Extensions.DependencyInjection;
using PowerPlant.Application.AutoMapper;
using System;

namespace PowerPlant.Api.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var mapperConfiguration = AutoMapperConfig.RegisterMappings();
            services.AddSingleton(mapperConfiguration.CreateMapper());
        }
    }
}
