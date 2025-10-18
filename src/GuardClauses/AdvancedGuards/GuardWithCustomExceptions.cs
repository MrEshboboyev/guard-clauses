using System.Runtime.CompilerServices;

namespace GuardClauses.AdvancedGuards;

/// <summary>
/// Factory class for creating fluent guard instances with custom exceptions
/// </summary>
public static class GuardWithCustomExceptions
{
    /// <summary>
    /// Creates a fluent guard with custom exceptions for the specified value
    /// </summary>
    public static FluentGuardWithCustomExceptions<T> For<T>(T value, [CallerArgumentExpression("value")] string paramName = null!)
    {
        return new FluentGuardWithCustomExceptions<T>(value, paramName ?? "value");
    }
}