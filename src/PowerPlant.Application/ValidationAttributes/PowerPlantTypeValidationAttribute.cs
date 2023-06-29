using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PowerPlant.Application.ValidationAttributes
{
    public class PowerPlantTypeValidationAttribute : ValidationAttribute
    {
        private readonly string[] powerplantTypes = { "gasfired", "turbojet", "windturbine" };

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (powerplantTypes?.Contains(value?.ToString()) == true)
            {
                return ValidationResult.Success;
            }

            var msg = $"Please fill one of the required powerplant types: {string.Join(", ", powerplantTypes)}.";
            return new ValidationResult(msg);
        }
    }
}
