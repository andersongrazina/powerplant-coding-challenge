using Newtonsoft.Json;

namespace PowerPlant.Application.DTO
{
    public class FuelsDTO
    {
        [JsonProperty("gas(euro/MWh)")]
        public decimal Gas { get; set; }

        [JsonProperty("kerosine(euro/MWh)")]
        public decimal Kerosine { get; set; }

        [JsonProperty("co2(euro/ton)")]
        public decimal Co2 { get; set; }

        [JsonProperty("wind(%)")]
        public decimal Wind { get; set; }
    }
}
