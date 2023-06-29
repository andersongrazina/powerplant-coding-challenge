using Microsoft.Extensions.DependencyInjection;
using PowerPlant.Application.Interfaces;
using PowerPlant.Application.Services;

namespace PowerPlant.Infra.CrossCutting.Ioc
{
    public class DependencyInjection
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IPowerCalculationAppService, PowerCalculationAppService>();
        }
    }
}
