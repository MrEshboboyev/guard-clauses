using System.Runtime.CompilerServices;
using GuardClauses.AdvancedGuards.Exceptions;

namespace GuardClauses.AdvancedGuards;

/// <summary>
/// Provides asynchronous guard clause validations
/// </summary>
public static class AsyncGuards
{
    /// <summary>
    /// Asynchronously validates that a value satisfies a condition
    /// </summary>
    public static async Task<T> SatisfiesAsync<T>(
        T value, 
        Func<T, Task<bool>> predicate, 
        string errorMessage,
        [CallerArgumentExpression("value")] string paramName = null!)
    {
        if (!(await predicate(value)))
            throw new ValidationException(errorMessage, paramName);
        return value;
    }

    /// <summary>
    /// Asynchronously validates that a value exists (e.g., in a database)
    /// </summary>
    public static async Task<T> ExistsAsync<T>(
        T? value, 
        Func<T, Task<bool>> existsPredicate, 
        string notFoundMessage = "The specified item was not found",
        [CallerArgumentExpression("value")] string paramName = null!) where T : class
    {
        if (value == null)
            throw new ValidationException(notFoundMessage, paramName);

        if (!(await existsPredicate(value)))
            throw new ValidationException(notFoundMessage, paramName);
            
        return value;
    }
}