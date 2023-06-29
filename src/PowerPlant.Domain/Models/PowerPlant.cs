namespace PowerPlant.Domain.Models
{
    public abstract class PowerPlant
    {
        public string Name { get; set; }
        public decimal Efficiency { get; set; }
        public int MinimumPowerAmount { get; set; }
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
