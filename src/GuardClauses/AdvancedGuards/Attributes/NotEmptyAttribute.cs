using GuardClauses.AdvancedGuards.Exceptions;

namespace GuardClauses.AdvancedGuards.Attributes;

/// <summary>
/// Attribute to validate that a string property is not empty
/// </summary>
public class NotEmptyAttribute : GuardAttribute
{
    /// <summary>
    /// Validates that the string value is not null or empty
    /// </summary>
    public override void Validate(object? value, string propertyName)
    {
        if (value is string str && string.IsNullOrEmpty(str))
            throw new ValidationException("The string cannot be null nor empty", propertyName);
    }
}