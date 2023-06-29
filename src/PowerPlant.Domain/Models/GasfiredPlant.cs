namespace PowerPlant.Domain.Models
{
    public class GasfiredPlant : PowerPlant
    {
        /// <summary>
        /// For this challenge, you may take into account that each MWh generated creates 0.3 ton of CO2.
        /// </summary>
        private const decimal TonPerMWh = 0.3m;

        /// <summary>
        /// gas (euro per MWh)
        /// </summary>
        private decimal Gas { get; }

        /// <summary>
        /// co2 (euro per ton)
        /// </summary>
        private decimal CO2 { get; }

        public GasfiredPlant(decimal gas, decimal co2)
        {
            Gas = gas;
            CO2 = co2;
        }

        public override decimal CalculateEnergyCost() => Gas / Efficiency;
    }
}