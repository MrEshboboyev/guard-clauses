using System.Runtime.CompilerServices;

namespace GuardClauses.AdvancedGuards;

/// <summary>
/// Factory class for creating fluent guard instances
/// </summary>
public static class Guard
{
    /// <summary>
    /// Creates a fluent guard for the specified value
    /// </summary>
    public static FluentGuard<T> For<T>(T value, [CallerArgumentExpression("value")] string paramName = null!)
    {
        return new FluentGuard<T>(value, paramName ?? "value");
    }
}