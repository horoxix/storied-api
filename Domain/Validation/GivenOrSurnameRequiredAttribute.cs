using System.ComponentModel.DataAnnotations;

using Domain.Commands;

namespace Domain.Validation
{
    public class GivenOrSurnameRequiredAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var command = (AddPersonCommand)validationContext.ObjectInstance;

            if (string.IsNullOrWhiteSpace(command.GivenName) &&
                string.IsNullOrWhiteSpace(command.Surname))
            {
                return new ValidationResult("At least one of Given Name or Surname is required.");
            }

            return ValidationResult.Success;
        }
    }
}
