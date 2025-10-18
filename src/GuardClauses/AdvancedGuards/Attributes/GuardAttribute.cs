namespace GuardClauses.AdvancedGuards.Attributes;

/// <summary>
/// Base attribute for guard clause validations
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public abstract class GuardAttribute : Attribute
{
    /// <summary>
    /// Validates the property value
    /// </summary>
    public abstract void Validate(object? value, string propertyName);
}