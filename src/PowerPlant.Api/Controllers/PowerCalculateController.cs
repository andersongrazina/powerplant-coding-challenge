using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PowerPlant.Application.DTO;
using PowerPlant.Application.Interfaces;
using System.Collections.Generic;

namespace PowerPlant.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class PowerCalculateController : ControllerBase
    {
        private readonly ILogger<PowerCalculateController> logger;
        private readonly IPowerCalculationAppService powerCalculateAppService;

        public PowerCalculateController(ILogger<PowerCalculateController> logger, IPowerCalculationAppService powerCalculateAppService)
        {
            this.logger = logger;
            this.powerCalculateAppService = powerCalculateAppService;
        }

        /// <summary>
        /// Calculate how much power each of a multitude of different powerplants need to produce when the load is given.
        /// </summary>
        /// <param name="payloadDTO">A payload structure contain the load, fuels and powerplants information.</param>
        /// <returns>returns how much power each powerplant should deliver</returns>
        /// <response code="400">If the item is null</response>  
        [HttpPost]
        public List<PowerPlantResponseDTO> Post([FromBody] PayloadDTO payloadDTO)
        {
            return powerCalculateAppService.CalculatePower(payloadDTO);
        }
    }
}
