using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PowerPlant.Application.DTO
{
    [JsonObject]
    public class PayloadDTO
    {
        [JsonProperty("load")]
        [Range(1, int.MaxValue, ErrorMessage = "The load value must be more than zero")]
        public int Load { get; set; }

        [JsonProperty("fuels")]
        public FuelsDTO Fuels { get; set; }

        [JsonProperty("powerplants")]
        public List<PowerPlantDTO> Powerplants { get; set; }
    }
}