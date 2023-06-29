namespace PowerPlant.Domain.Models
{
    public class PowerSupply
    {
        public PowerSupply(int powerProduced)
        {
            PowerProduced = powerProduced;
        }

        public string PowerPlant { get; set; }
        public decimal EnergyCost { get; set; }
        public int PowerProduced { get; set; }
        public decimal TotalCost => EnergyCost * PowerProduced;
        public int MinimumPowerAmount { get; set; }
        public int MaximumPowerAmount { get; set; }
    }
}
