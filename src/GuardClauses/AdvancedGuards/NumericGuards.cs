using System.Runtime.CompilerServices;
using GuardClauses.AdvancedGuards.Exceptions;

namespace GuardClauses.AdvancedGuards;

/// <summary>
/// Extension methods for numeric guard clauses
/// </summary>
public static class NumericGuards
{
    /// <summary>
    /// Ensures that a number is positive
    /// </summary>
    public static T Positive<T>(this T value, [CallerArgumentExpression("value")] string paramName = null!) 
        where T : struct, IComparable<T>
    {
        if (value.CompareTo(default(T)) <= 0)
            throw new ValidationException("The value must be positive", paramName);
        return value;
    }

    /// <summary>
    /// Ensures that a number is non-negative
    /// </summary>
    public static T NonNegative<T>(this T value, [CallerArgumentExpression("value")] string paramName = null!) 
        where T : struct, IComparable<T>
    {
        if (value.CompareTo(default(T)) < 0)
            throw new ValidationException("The value cannot be negative", paramName);
        return value;
    }

    /// <summary>
    /// Ensures that a number is within a range
    /// </summary>
    public static T Between<T>(this T value, T min, T max, [CallerArgumentExpression("value")] string paramName = null!) 
        where T : struct, IComparable<T>
    {
        if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0)
            throw new ValidationException($"The value must be between {min} and {max}", paramName);
        return value;
    }

    /// <summary>
    /// Ensures that a number is even
    /// </summary>
    public static int Even(this int value, [CallerArgumentExpression("value")] string paramName = null!)
    {
        if (value % 2 != 0)
            throw new ValidationException("The value must be even", paramName);
        return value;
    }

    /// <summary>
    /// Ensures that a number is odd
    /// </summary>
    public static int Odd(this int value, [CallerArgumentExpression("value")] string paramName = null!)
    {
        if (value % 2 == 0)
            throw new ValidationException("The value must be odd", paramName);
        return value;
    }

    /// <summary>
    /// Ensures that a decimal has at most the specified number of decimal places
    /// </summary>
    public static decimal MaxDecimalPlaces(this decimal value, int decimalPlaces, [CallerArgumentExpression("value")] string paramName = null!)
    {
        var rounded = Math.Round(value, decimalPlaces);
        if (rounded != value)
            throw new ValidationException($"The value cannot have more than {decimalPlaces} decimal places", paramName);
        return value;
    }
}