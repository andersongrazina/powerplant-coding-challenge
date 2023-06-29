using PowerPlant.Application.DTO;
using System.Collections.Generic;

namespace PowerPlant.Application.Interfaces
{
    public interface IPowerCalculationAppService
    {
        List<PowerPlantResponseDTO> CalculatePower(PayloadDTO payloadDTO);
    }
}