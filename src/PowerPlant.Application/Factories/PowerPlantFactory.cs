using AutoMapper;
using PowerPlant.Application.DTO;
using PowerPlant.Domain.Models;
using System;
using Models = PowerPlant.Domain.Models;

namespace PowerPlant.Application.Factories
{
    public static class PowerPlantFactory
    {
        public static Models.PowerPlant Build(IMapper mapper, FuelsDTO fuelsDTO, PowerPlantDTO powerPlantDTO)
        {
            switch (powerPlantDTO.Type)
            {
                case "gasfired": { return mapper.Map(powerPlantDTO, new GasfiredPlant(fuelsDTO.Gas, fuelsDTO.Co2)); }
                case "turbojet": { return mapper.Map(powerPlantDTO, new TurboJetPlant(fuelsDTO.Kerosine)); }
                case "windturbine": { return mapper.Map(powerPlantDTO, new WindTurbinePlant(fuelsDTO.Wind)); }
            }

            throw new Exception("PowerPlant type not recognized");
        }
    }
}
