using System.ComponentModel.DataAnnotations;

namespace Domain.Validation;

public class AtLeastOnePropertyRequiredAttribute : ValidationAttribute
{
    private readonly string[] _propertyNames;

    public AtLeastOnePropertyRequiredAttribute(params string[] propertyNames)
    {
        _propertyNames = propertyNames;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var command = validationContext.ObjectInstance;

        foreach (var propertyName in _propertyNames)
        {
            var propertyInfo = command.GetType().GetProperty(propertyName);
            var propertyValue = propertyInfo?.GetValue(command);

            if (propertyValue != null && !string.IsNullOrWhiteSpace(propertyValue.ToString()))
            {
                return ValidationResult.Success;
            }
        }

        return new ValidationResult($"At least one of {_propertyNames} is required.");
    }
}
