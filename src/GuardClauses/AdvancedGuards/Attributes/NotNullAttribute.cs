using GuardClauses.AdvancedGuards.Exceptions;

namespace GuardClauses.AdvancedGuards.Attributes;

/// <summary>
/// Attribute to validate that a property is not null
/// </summary>
public class NotNullAttribute : GuardAttribute
{
    /// <summary>
    /// Validates that the value is not null
    /// </summary>
    public override void Validate(object? value, string propertyName)
    {
        if (value is null)
            throw new ValidationException("The value cannot be null", propertyName);
    }
}