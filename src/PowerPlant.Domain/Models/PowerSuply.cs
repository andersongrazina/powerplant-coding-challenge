namespace PowerPlant.Domain.Models
{
    public class PowerSupply
    {
        public PowerSupply(int powerProduced)
        {
            PowerProduced = powerProduced;
        }

        /// <summary>
        /// Power Plant Name
        /// </summary>
        public string PowerPlant { get; set; }

        /// <summary>
        /// Energy Cost
        /// </summary>
        public decimal EnergyCost { get; set; }

        /// <summary>
        /// Power Produced
        /// </summary>
        public int PowerProduced { get; set; }
        public decimal TotalCost => EnergyCost * PowerProduced;

        /// <summary>
        /// Minimum Power Amount
        /// </summary>
        public int MinimumPowerAmount { get; set; }

        /// <summary>
        /// Maximum Power Amount
        /// </summary>
        public int MaximumPowerAmount { get; set; }
    }
}
