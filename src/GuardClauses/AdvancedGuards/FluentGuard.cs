using System.Runtime.CompilerServices;

namespace GuardClauses.AdvancedGuards;

/// <summary>
/// Provides a fluent API for guard clause validations
/// </summary>
public class FluentGuard<T>
{
    private readonly T _value;
    private readonly string _paramName;

    internal FluentGuard(T value, string paramName)
    {
        _value = value;
        _paramName = paramName;
    }

    /// <summary>
    /// Throws an exception if the value is null
    /// </summary>
    public FluentGuard<T> NotNull()
    {
        if (_value is null)
            throw new ArgumentNullException(_paramName, "The value cannot be null");
        return this;
    }

    /// <summary>
    /// Throws an exception if the string is null or empty
    /// </summary>
    public FluentGuard<string> NotNullOrEmpty()
    {
        if (_value is string str && string.IsNullOrEmpty(str))
            throw new ArgumentNullException(_paramName, "The string cannot be null nor empty");
        
        return (FluentGuard<string>)(object)this;
    }

    /// <summary>
    /// Throws an exception if the value is negative (for numeric types)
    /// </summary>
    public FluentGuard<T> NotNegative()
    {
        // Handle different numeric types
        switch (_value)
        {
            case int intValue when intValue < 0:
                throw new ArgumentOutOfRangeException(_paramName, "The value cannot be negative");
            case decimal decimalValue when decimalValue < 0:
                throw new ArgumentOutOfRangeException(_paramName, "The value cannot be negative");
            case long longValue when longValue < 0:
                throw new ArgumentOutOfRangeException(_paramName, "The value cannot be negative");
            case double doubleValue when doubleValue < 0:
                throw new ArgumentOutOfRangeException(_paramName, "The value cannot be negative");
            case float floatValue when floatValue < 0:
                throw new ArgumentOutOfRangeException(_paramName, "The value cannot be negative");
        }
        return this;
    }

    /// <summary>
    /// Throws an exception if the value is zero or negative (for numeric types)
    /// </summary>
    public FluentGuard<T> NotZeroOrNegative()
    {
        // Handle different numeric types
        switch (_value)
        {
            case int intValue when intValue <= 0:
                throw new ArgumentOutOfRangeException(_paramName, "The value cannot be zero or negative");
            case decimal decimalValue when decimalValue <= 0:
                throw new ArgumentOutOfRangeException(_paramName, "The value cannot be zero or negative");
            case long longValue when longValue <= 0:
                throw new ArgumentOutOfRangeException(_paramName, "The value cannot be zero or negative");
            case double doubleValue when doubleValue <= 0:
                throw new ArgumentOutOfRangeException(_paramName, "The value cannot be zero or negative");
            case float floatValue when floatValue <= 0:
                throw new ArgumentOutOfRangeException(_paramName, "The value cannot be zero or negative");
        }
        return this;
    }

    /// <summary>
    /// Throws an exception if the value is outside the specified range (for numeric types)
    /// </summary>
    public FluentGuard<T> InRange(object min, object max)
    {
        // Handle different numeric types
        switch (_value)
        {
            case int intValue:
                if (min is int minInt && max is int maxInt && (intValue < minInt || intValue > maxInt))
                    throw new ArgumentOutOfRangeException(_paramName, $"The value must be between {minInt} and {maxInt}");
                break;
            case decimal decimalValue:
                if (min is decimal minDecimal && max is decimal maxDecimal && (decimalValue < minDecimal || decimalValue > maxDecimal))
                    throw new ArgumentOutOfRangeException(_paramName, $"The value must be between {minDecimal} and {maxDecimal}");
                break;
            case long longValue:
                if (min is long minLong && max is long maxLong && (longValue < minLong || longValue > maxLong))
                    throw new ArgumentOutOfRangeException(_paramName, $"The value must be between {minLong} and {maxLong}");
                break;
            case double doubleValue:
                if (min is double minDouble && max is double maxDouble && (doubleValue < minDouble || doubleValue > maxDouble))
                    throw new ArgumentOutOfRangeException(_paramName, $"The value must be between {minDouble} and {maxDouble}");
                break;
            case float floatValue:
                if (min is float minFloat && max is float maxFloat && (floatValue < minFloat || floatValue > maxFloat))
                    throw new ArgumentOutOfRangeException(_paramName, $"The value must be between {minFloat} and {maxFloat}");
                break;
        }
        return this;
    }

    /// <summary>
    /// Throws an exception if the value doesn't match the specified pattern
    /// </summary>
    public FluentGuard<string> MatchesRegex(string pattern)
    {
        if (_value is string str && !System.Text.RegularExpressions.Regex.IsMatch(str, pattern))
            throw new ArgumentException($"The value does not match the required pattern: {pattern}", _paramName);
        return (FluentGuard<string>)(object)this;
    }

    /// <summary>
    /// Custom validation with a predicate
    /// </summary>
    public FluentGuard<T> Satisfies(Func<T, bool> predicate, string errorMessage)
    {
        if (!predicate(_value))
            throw new ArgumentException(errorMessage, _paramName);
        return this;
    }

    /// <summary>
    /// Returns the validated value
    /// </summary>
    public T Value => _value;
}