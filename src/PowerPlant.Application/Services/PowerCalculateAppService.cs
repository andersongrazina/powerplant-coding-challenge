using AutoMapper;
using PowerPlant.Application.DTO;
using PowerPlant.Application.Factories;
using PowerPlant.Application.Interfaces;
using PowerPlant.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using Models = PowerPlant.Domain.Models;

namespace PowerPlant.Application.Services
{
    public class PowerCalculationAppService : IPowerCalculationAppService
    {
        private readonly IMapper mapper;

        public PowerCalculationAppService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public List<PowerPlantResponse> CalculatePower(PayloadDTO payloadDTO)
        {
            var powerplants = new List<Models.PowerPlant>();
            var supplyRequireds = new List<PowerSupply>();
            var loadingRequired = payloadDTO.Load;

            foreach (var powerplantDTO in payloadDTO.Powerplants)
            {
                powerplants.Add(PowerPlantFactory.Build(mapper, payloadDTO.Fuels, powerplantDTO));
            }

            foreach (var powerplant in powerplants.OrderBy(p => p.CalculateEnergyCost()).ThenBy(p => p.MinimumPowerAmount))
            {
                if (loadingRequired == 0)
                {
                    break;
                }

                if (loadingRequired < powerplant.MinimumPowerAmount)
                {
                    var requiredDeficit = powerplant.MinimumPowerAmount - loadingRequired;
                    foreach (var supplyRequired in supplyRequireds.OrderByDescending(s => s.EnergyCost))
                    {
                        if (requiredDeficit == 0)
                        {
                            break;
                        }

                        var deficit = supplyRequired.PowerProduced - requiredDeficit < supplyRequired.MinimumPowerAmount ?
                            supplyRequired.PowerProduced - supplyRequired.MinimumPowerAmount : requiredDeficit;

                        deficit = deficit > supplyRequired.MaximumPowerAmount ? supplyRequired.MaximumPowerAmount : deficit;

                        supplyRequired.PowerProduced -= deficit;
                        requiredDeficit -= deficit;
                        loadingRequired += deficit;
                    }
                }

                if (powerplant.CanOperate())
                {
                    var powerProduced = powerplant.ProducePower(loadingRequired);
                    if (powerProduced > 0)
                    {
                        loadingRequired -= powerProduced;
                        supplyRequireds.Add(mapper.Map(powerplant, new Models.PowerSupply(powerProduced)));
                    }
                }
            }

            return supplyRequireds.Select(s => new PowerPlantResponse { Name = s.PowerPlant, Power = s.PowerProduced }).ToList();
        }
    }
}