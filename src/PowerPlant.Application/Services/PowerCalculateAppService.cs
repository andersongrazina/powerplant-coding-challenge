using AutoMapper;
using PowerPlant.Application.DTO;
using PowerPlant.Application.Factories;
using PowerPlant.Application.Interfaces;
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
            var powerplants = BuildPowerPlants(payloadDTO);
            var supplyAmountRequired = new List<Models.PowerSupply>();
            var loadingRequired = payloadDTO.Load;

            foreach (var powerplant in powerplants.OrderBy(p => p.CalculateEnergyCost()).ThenBy(p => p.MinimumPowerAmount))
            {
                var powerProduced = 0;
                if (loadingRequired > 0)
                {
                    if (loadingRequired < powerplant.MinimumPowerAmount)
                    {
                        RedistributeSupplyAmount(powerplant, supplyAmountRequired, ref loadingRequired);
                    }


                    if (powerplant.CanOperate())
                    {
                        powerProduced = powerplant.ProducePower(loadingRequired);
                        if (powerProduced > 0)
                        {
                            loadingRequired -= powerProduced;
                        }
                    }
                }

                supplyAmountRequired.Add(mapper.Map(powerplant, new Models.PowerSupply(powerProduced)));
            }

            return supplyAmountRequired.Select(s => mapper.Map<PowerPlantResponse>(s)).ToList();
        }

        private IEnumerable<Models.PowerPlant> BuildPowerPlants(PayloadDTO payloadDTO)
        {
            foreach (var powerplantDTO in payloadDTO.Powerplants)
            {
                yield return PowerPlantFactory.Build(mapper, payloadDTO.Fuels, powerplantDTO);
            }
        }

        private void RedistributeSupplyAmount(Models.PowerPlant powerplant, List<Models.PowerSupply> supplyAmountRequired, ref int loadingRequired)
        {
            var requiredDeficit = powerplant.MinimumPowerAmount - loadingRequired;
            foreach (var supplyRequired in supplyAmountRequired.OrderByDescending(s => s.EnergyCost))
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
    }
}
