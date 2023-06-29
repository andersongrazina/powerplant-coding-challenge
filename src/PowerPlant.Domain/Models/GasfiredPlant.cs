namespace PowerPlant.Domain.Models
{
    public class GasfiredPlant : PowerPlant
    {
        /// <summary>
        /// Ton Per MWh
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

        public override decimal CalculateEnergyCost()
        {
            throw new System.NotImplementedException();
        }

        public override decimal ProducePower(int load)
        {
            throw new System.NotImplementedException();
        }

        public decimal CalculateCO2Cost()
        {
            return 0;
        }
    }
}
