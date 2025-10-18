using System.Runtime.CompilerServices;

namespace GuardClauses;

public static class Ensure
{
    public static T NotNull<T>(T? value, [CallerArgumentExpression("value")] string? paramName = null) where T : class
    {
        if (value is null) throw new ArgumentNullException(
            paramName, "The value cannot be null");
        return value;
    }
    
    public static string NotNullOrEmpty(string? value, [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(
            paramName, "The string cannot be null nor empty");
        return value;
    }
    
    public static IReadOnlyList<T> NotNullOrEmptyList<T>(IReadOnlyList<T>? list, [CallerArgumentExpression("list")] string? paramName = null)
    {
        if (list is null || list.Count == 0)
        {
            throw new ArgumentException("The list should contain at least 1 item.", paramName);
        }
        return list;
    }
    
    public static T NotDefault<T>(T value, [CallerArgumentExpression("value")] string? paramName = null) where T : struct
    {
        if (EqualityComparer<T>.Default.Equals(value, default(T)))
        {
            throw new ArgumentException("The value cannot be the default value.", paramName);
        }
        return value;
    }
    
    public static int NotNegative(int value, [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(paramName, "The value cannot be negative.");
        }
        return value;
    }
    
    public static int NotZeroOrNegative(int value, [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException(paramName, "The value cannot be zero or negative.");
        }
        return value;
    }
    
    public static decimal NotNegative(decimal value, [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(paramName, "The value cannot be negative.");
        }
        return value;
    }
    
    public static decimal NotZeroOrNegative(decimal value, [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException(paramName, "The value cannot be zero or negative.");
        }
        return value;
    }
    
    public static T InRange<T>(T value, T min, T max, [CallerArgumentExpression("value")] string? paramName = null) 
        where T : IComparable<T>
    {
        if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0)
        {
            throw new ArgumentOutOfRangeException(paramName, $"The value must be between {min} and {max}.");
        }
        return value;
    }
    
    public static string MatchesRegex(string value, string pattern, [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (!System.Text.RegularExpressions.Regex.IsMatch(value, pattern))
        {
            throw new ArgumentException($"The value does not match the required pattern: {pattern}", paramName);
        }
        return value;
    }
}
