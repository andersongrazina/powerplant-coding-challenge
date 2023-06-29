using System;

namespace PowerPlant.Domain.Models
{
    public class TurboJetPlant : PowerPlant
    {
        /// <summary>
        /// Kerosine (euro per MWh)
        /// </summary>
        private decimal Kerosine { get; }

        public TurboJetPlant(decimal kerosine)
        {
            Kerosine = kerosine;
        }

        public override decimal CalculateEnergyCost()
        {
            throw new NotImplementedException();
        }

        public override decimal ProducePower(int load)
        {
            throw new NotImplementedException();
        }
    }
}
