using Xunit;
using Microsoft.Extensions.Logging;
using PowerPlant.Api.Controllers;
using PowerPlant.Application.Interfaces;
using NSubstitute;
using System;
using PowerPlant.Application.DTO;
using System.Collections.Generic;

namespace PowerPlant.Api.Test
{
    public class PowerCalculateControllerTest
    {
        private ILogger<PowerCalculateController> logger;
        private IPowerCalculationAppService powerCalculateAppService;
        private PowerCalculateController powerCalculateController;

        public PowerCalculateControllerTest()
        {
            logger = Substitute.For<ILogger<PowerCalculateController>>();
            powerCalculateAppService = Substitute.For<IPowerCalculationAppService>();

            powerCalculateController = new PowerCalculateController(logger, powerCalculateAppService);
        }

        [Fact]
        public void ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new PowerCalculateController(null, powerCalculateAppService));
            Assert.Throws<ArgumentNullException>(() => new PowerCalculateController(logger, null));
        }

        [Fact]
        public void ShouldReturnPowerPlantResponseList()
        {
            //Arrange
            List<PowerPlantResponse> expectedList = new List<PowerPlantResponse> { new PowerPlantResponse() };
            PayloadDTO payloadDTO = Substitute.For<PayloadDTO>();
            powerCalculateAppService.CalculatePower(payloadDTO).Returns(expectedList);

            //Act
            var response = powerCalculateController.Post(payloadDTO);

            //Assert
            Assert.Equal(expectedList, response);
        }
    }
}
