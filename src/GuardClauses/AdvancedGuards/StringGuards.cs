using System.Runtime.CompilerServices;
using GuardClauses.AdvancedGuards.Exceptions;

namespace GuardClauses.AdvancedGuards;

/// <summary>
/// Extension methods for string guard clauses
/// </summary>
public static class StringGuards
{
    /// <summary>
    /// Ensures that a string is not null, empty, or whitespace
    /// </summary>
    public static string NotNullOrWhiteSpace(this string value, [CallerArgumentExpression("value")] string paramName = null!)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ValidationException("The string cannot be null, empty, or whitespace", paramName);
        return value;
    }

    /// <summary>
    /// Ensures that a string has a minimum length
    /// </summary>
    public static string HasMinimumLength(this string value, int minimumLength, [CallerArgumentExpression("value")] string paramName = null!)
    {
        if (value.Length < minimumLength)
            throw new ValidationException($"The string must have at least {minimumLength} characters", paramName);
        return value;
    }

    /// <summary>
    /// Ensures that a string has a maximum length
    /// </summary>
    public static string HasMaximumLength(this string value, int maximumLength, [CallerArgumentExpression("value")] string paramName = null!)
    {
        if (value.Length > maximumLength)
            throw new ValidationException($"The string must have at most {maximumLength} characters", paramName);
        return value;
    }

    /// <summary>
    /// Ensures that a string matches a specific pattern
    /// </summary>
    public static string Matches(this string value, string pattern, [CallerArgumentExpression("value")] string paramName = null!)
    {
        if (!System.Text.RegularExpressions.Regex.IsMatch(value, pattern))
            throw new ValidationException($"The string does not match the required pattern: {pattern}", paramName);
        return value;
    }

    /// <summary>
    /// Ensures that a string is a valid email address
    /// </summary>
    public static string ValidEmail(this string value, [CallerArgumentExpression("value")] string paramName = null!)
    {
        if (!System.Text.RegularExpressions.Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            throw new ValidationException("The string is not a valid email address", paramName);
        return value;
    }

    /// <summary>
    /// Ensures that a string is a valid URL
    /// </summary>
    public static string ValidUrl(this string value, [CallerArgumentExpression("value")] string paramName = null!)
    {
        if (!Uri.TryCreate(value, UriKind.Absolute, out _))
            throw new ValidationException("The string is not a valid URL", paramName);
        return value;
    }
}