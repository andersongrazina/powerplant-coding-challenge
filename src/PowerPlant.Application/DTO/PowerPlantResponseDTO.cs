using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PowerPlant.Application.DTO
{
    public class PowerPlantResponseDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("p")]
        public int Power { get; set; }
    }
}
