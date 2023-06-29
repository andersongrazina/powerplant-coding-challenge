using PowerPlant.Application.DTO;
using System.ComponentModel.DataAnnotations;

namespace PowerPlant.Application.ValidationAttributes
{
    public class PowerPlantMinimumPowerValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var powerplantDTO = (PowerPlantDTO)validationContext.ObjectInstance;

            if (powerplantDTO.Pmax > powerplantDTO.Pmin)
            {
                return ValidationResult.Success;
            }

            var msg = $"The minimum power(pmin) can't be higher than the maximum power(pmax)";
            return new ValidationResult(msg);
        }
    }
}
