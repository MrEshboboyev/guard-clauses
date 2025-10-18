using System.Runtime.CompilerServices;
using GuardClauses.AdvancedGuards.Exceptions;

namespace GuardClauses.AdvancedGuards;

/// <summary>
/// Extension methods for DateTime guard clauses
/// </summary>
public static class DateTimeGuards
{
    /// <summary>
    /// Ensures that a DateTime is not in the past
    /// </summary>
    public static DateTime NotInPast(this DateTime value, [CallerArgumentExpression("value")] string paramName = null!)
    {
        if (value < DateTime.Now)
            throw new ValidationException("The date cannot be in the past", paramName);
        return value;
    }

    /// <summary>
    /// Ensures that a DateTime is not in the future
    /// </summary>
    public static DateTime NotInFuture(this DateTime value, [CallerArgumentExpression("value")] string paramName = null!)
    {
        if (value > DateTime.Now)
            throw new ValidationException("The date cannot be in the future", paramName);
        return value;
    }

    /// <summary>
    /// Ensures that a DateTime is within a range
    /// </summary>
    public static DateTime Between(this DateTime value, DateTime min, DateTime max, [CallerArgumentExpression("value")] string paramName = null!)
    {
        if (value < min || value > max)
            throw new ValidationException($"The date must be between {min} and {max}", paramName);
        return value;
    }

    /// <summary>
    /// Ensures that a DateTime is a weekday
    /// </summary>
    public static DateTime Weekday(this DateTime value, [CallerArgumentExpression("value")] string paramName = null!)
    {
        if (value.DayOfWeek == DayOfWeek.Saturday || value.DayOfWeek == DayOfWeek.Sunday)
            throw new ValidationException("The date must be a weekday", paramName);
        return value;
    }

    /// <summary>
    /// Ensures that a DateTime is a weekend
    /// </summary>
    public static DateTime Weekend(this DateTime value, [CallerArgumentExpression("value")] string paramName = null!)
    {
        if (value.DayOfWeek != DayOfWeek.Saturday && value.DayOfWeek != DayOfWeek.Sunday)
            throw new ValidationException("The date must be a weekend", paramName);
        return value;
    }
}