using System.Reflection;

namespace GuardClauses.AdvancedGuards.Attributes;

/// <summary>
/// Validates objects using guard attributes
/// </summary>
public static class ObjectValidator
{
    /// <summary>
    /// Validates an object's properties using guard attributes
    /// </summary>
    public static void Validate(object obj)
    {
        var type = obj.GetType();
        var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var property in properties)
        {
            var guardAttributes = property.GetCustomAttributes<GuardAttribute>(true);
            var value = property.GetValue(obj);

            foreach (var attribute in guardAttributes)
            {
                attribute.Validate(value, property.Name);
            }
        }
    }
}