using PowerPlant.Application.DTO;
using System.Collections.Generic;

namespace PowerPlant.Application.Interfaces
{
    public interface IPowerCalculationAppService
    {
        List<PowerPlantResponse> CalculatePower(PayloadDTO payloadDTO);
    }
}