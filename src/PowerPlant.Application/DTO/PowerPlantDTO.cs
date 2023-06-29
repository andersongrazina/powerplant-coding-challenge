using Newtonsoft.Json;
using PowerPlant.Application.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace PowerPlant.Application.DTO
{
    [JsonObject]
    public class PowerPlantDTO
    {
        [JsonProperty("name")]
        [Required]
        public string Name { get; set; }

        [JsonProperty("type")]
        [Required]
        [PowerPlantTypeValidation]
        public string Type { get; set; }

        [JsonProperty("efficiency")]
        public decimal Efficiency { get; set; }

        [JsonProperty("pmin")]
        [PowerPlantMinimumPowerValidation]
        public int Pmin { get; set; }

        [JsonProperty("pmax")]
        public int Pmax { get; set; }
    }
}
