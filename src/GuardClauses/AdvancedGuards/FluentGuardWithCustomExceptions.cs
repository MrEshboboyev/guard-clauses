using System.Runtime.CompilerServices;
using GuardClauses.AdvancedGuards.Exceptions;

namespace GuardClauses.AdvancedGuards;

/// <summary>
/// Provides a fluent API for guard clause validations with custom exceptions
/// </summary>
public class FluentGuardWithCustomExceptions<T>
{
    private readonly T _value;
    private readonly string _paramName;

    internal FluentGuardWithCustomExceptions(T value, string paramName)
    {
        _value = value;
        _paramName = paramName;
    }

    /// <summary>
    /// Throws a ValidationException if the value is null
    /// </summary>
    public FluentGuardWithCustomExceptions<T> NotNull()
    {
        if (_value is null)
            throw new ValidationException("The value cannot be null", _paramName);
        return this;
    }

    /// <summary>
    /// Throws a ValidationException if the string is null or empty
    /// </summary>
    public FluentGuardWithCustomExceptions<string> NotNullOrEmpty()
    {
        if (_value is string str && string.IsNullOrEmpty(str))
            throw new ValidationException("The string cannot be null nor empty", _paramName);
        
        return (FluentGuardWithCustomExceptions<string>)(object)this;
    }

    /// <summary>
    /// Throws a ValidationException if the value is negative (for numeric types)
    /// </summary>
    public FluentGuardWithCustomExceptions<T> NotNegative()
    {
        // Handle different numeric types
        switch (_value)
        {
            case int intValue when intValue < 0:
                throw new ValidationException("The value cannot be negative", _paramName);
            case decimal decimalValue when decimalValue < 0:
                throw new ValidationException("The value cannot be negative", _paramName);
            case long longValue when longValue < 0:
                throw new ValidationException("The value cannot be negative", _paramName);
            case double doubleValue when doubleValue < 0:
                throw new ValidationException("The value cannot be negative", _paramName);
            case float floatValue when floatValue < 0:
                throw new ValidationException("The value cannot be negative", _paramName);
        }
        return this;
    }

    /// <summary>
    /// Throws a ValidationException if the value is zero or negative (for numeric types)
    /// </summary>
    public FluentGuardWithCustomExceptions<T> NotZeroOrNegative()
    {
        // Handle different numeric types
        switch (_value)
        {
            case int intValue when intValue <= 0:
                throw new ValidationException("The value cannot be zero or negative", _paramName);
            case decimal decimalValue when decimalValue <= 0:
                throw new ValidationException("The value cannot be zero or negative", _paramName);
            case long longValue when longValue <= 0:
                throw new ValidationException("The value cannot be zero or negative", _paramName);
            case double doubleValue when doubleValue <= 0:
                throw new ValidationException("The value cannot be zero or negative", _paramName);
            case float floatValue when floatValue <= 0:
                throw new ValidationException("The value cannot be zero or negative", _paramName);
        }
        return this;
    }

    /// <summary>
    /// Throws a ValidationException if the value is outside the specified range (for numeric types)
    /// </summary>
    public FluentGuardWithCustomExceptions<T> InRange(object min, object max)
    {
        // Handle different numeric types
        switch (_value)
        {
            case int intValue:
                if (min is int minInt && max is int maxInt && (intValue < minInt || intValue > maxInt))
                    throw new ValidationException($"The value must be between {minInt} and {maxInt}", _paramName);
                break;
            case decimal decimalValue:
                if (min is decimal minDecimal && max is decimal maxDecimal && (decimalValue < minDecimal || decimalValue > maxDecimal))
                    throw new ValidationException($"The value must be between {minDecimal} and {maxDecimal}", _paramName);
                break;
            case long longValue:
                if (min is long minLong && max is long maxLong && (longValue < minLong || longValue > maxLong))
                    throw new ValidationException($"The value must be between {minLong} and {maxLong}", _paramName);
                break;
            case double doubleValue:
                if (min is double minDouble && max is double maxDouble && (doubleValue < minDouble || doubleValue > maxDouble))
                    throw new ValidationException($"The value must be between {minDouble} and {maxDouble}", _paramName);
                break;
            case float floatValue:
                if (min is float minFloat && max is float maxFloat && (floatValue < minFloat || floatValue > maxFloat))
                    throw new ValidationException($"The value must be between {minFloat} and {maxFloat}", _paramName);
                break;
        }
        return this;
    }

    /// <summary>
    /// Throws a ValidationException if the value doesn't match the specified pattern
    /// </summary>
    public FluentGuardWithCustomExceptions<string> MatchesRegex(string pattern)
    {
        if (_value is string str && !System.Text.RegularExpressions.Regex.IsMatch(str, pattern))
            throw new ValidationException($"The value does not match the required pattern: {pattern}", _paramName);
        return (FluentGuardWithCustomExceptions<string>)(object)this;
    }

    /// <summary>
    /// Custom validation with a predicate and custom exception
    /// </summary>
    public FluentGuardWithCustomExceptions<T> Satisfies(Func<T, bool> predicate, string errorMessage)
    {
        if (!predicate(_value))
            throw new ValidationException(errorMessage, _paramName);
        return this;
    }

    /// <summary>
    /// Returns the validated value
    /// </summary>
    public T Value => _value;
}