using System;
using System.Collections.Generic;
using AutoMapper;
using NSubstitute;
using PowerPlant.Application.DTO;
using PowerPlant.Application.Services;
using PowerPlant.Domain.Models;
using Xunit;

namespace PowerPlant.Application.Test.Services
{
    public class PowerCalculateAppServiceTest
    {
        private IMapper mapper;
        private PowerCalculationAppService powerCalculateAppService;

        public PowerCalculateAppServiceTest()
        {
            mapper = Substitute.For<IMapper>();
            powerCalculateAppService = new PowerCalculationAppService(mapper);
        }

        [Fact]
        public void ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new PowerCalculationAppService(null));
        }

        [Fact]
        public void ShouldReturnPowerPlantResponseList()
        {
            //Arrange
            PowerPlantDTO powerPlantDTO = new PowerPlantDTO() { Name = "Test", Efficiency = 3, Pmax = 14, Pmin = 2, Type = "windturbine" };
            PowerPlantDTO powerPlantDTO2 = new PowerPlantDTO() { Name = "Test2", Efficiency = 2, Pmax = 15, Pmin = 6, Type = "gasfired" };

            PayloadDTO payloadDTO = new PayloadDTO()
            {
                Load = 8,
                Fuels = new FuelsDTO()
                {
                    Co2 = 2,
                    Gas = 2,
                    Kerosine = 2,
                    Wind = 2
                },
                Powerplants = new List<PowerPlantDTO>()
                {
                    powerPlantDTO,
                    powerPlantDTO2
                }
            };

            mapper.Map(Arg.Any<PowerPlantDTO>(), Arg.Any<WindTurbinePlant>())
                .Returns(new WindTurbinePlant(payloadDTO.Fuels.Wind)
                {
                    Efficiency = powerPlantDTO.Efficiency,
                    MaximumPowerAmount = powerPlantDTO.Pmax,
                    MinimumPowerAmount = powerPlantDTO.Pmin,
                    Name = powerPlantDTO.Name
                });

            mapper.Map(Arg.Any<PowerPlantDTO>(), Arg.Any<GasfiredPlant>())
                .Returns(new GasfiredPlant(payloadDTO.Fuels.Gas, payloadDTO.Fuels.Co2)
                {
                    Efficiency = powerPlantDTO.Efficiency,
                    MaximumPowerAmount = powerPlantDTO.Pmax,
                    MinimumPowerAmount = powerPlantDTO.Pmin,
                    Name = powerPlantDTO.Name
                });

            //Act
            var response = new PowerCalculationAppService(mapper).CalculatePower(payloadDTO);

            //Assert
            Assert.True(response.Count == 2);
        }
    }
}
