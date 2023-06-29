namespace PowerPlant.Domain.Models
{
    public abstract class PowerPlant
    {

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Efficiency
        /// </summary>
        public decimal Efficiency { get; set; }

        /// <summary>
        /// Minimum Power Amount
        /// </summary>
        public int MinimumPowerAmount { get; set; }

        /// <summary>
        /// Maximum Power Amount
        /// </summary>
        public int MaximumPowerAmount { get; set; }

        /// <summary>
        /// Give the cost to generate MWh in euro
        /// </summary>
        /// <returns>Return the value in Euro</returns>
        public abstract decimal CalculateEnergyCost();

        public virtual int ProducePower(int load)
        {
            if (MinimumPowerAmount > load)
            {
                return 0;
            }

            return load > MaximumPowerAmount ? MaximumPowerAmount : load;
        }

        public virtual bool CanOperate() => Efficiency > 0 && MaximumPowerAmount > 0;
    }
}
