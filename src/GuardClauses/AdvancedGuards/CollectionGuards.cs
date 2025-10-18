using System.Collections;
using System.Runtime.CompilerServices;
using GuardClauses.AdvancedGuards.Exceptions;

namespace GuardClauses.AdvancedGuards;

/// <summary>
/// Extension methods for collection guard clauses
/// </summary>
public static class CollectionGuards
{
    /// <summary>
    /// Ensures that a collection is not null or empty
    /// </summary>
    public static T NotNullOrEmpty<T>(this T collection, [CallerArgumentExpression("collection")] string paramName = null!) 
        where T : IEnumerable
    {
        if (collection == null)
            throw new ValidationException("The collection cannot be null", paramName);

        // Check if it's an ICollection to efficiently check count
        if (collection is ICollection icollection)
        {
            if (icollection.Count == 0)
                throw new ValidationException("The collection cannot be empty", paramName);
        }
        else
        {
            // For other enumerables, we need to iterate to check if empty
            var enumerator = collection.GetEnumerator();
            try
            {
                if (!enumerator.MoveNext())
                    throw new ValidationException("The collection cannot be empty", paramName);
            }
            finally
            {
                if (enumerator is IDisposable disposable)
                    disposable.Dispose();
            }
        }

        return collection;
    }

    /// <summary>
    /// Ensures that a collection has at least the specified number of elements
    /// </summary>
    public static T HasMinimumCount<T>(this T collection, int minimumCount, [CallerArgumentExpression("collection")] string paramName = null!) 
        where T : IEnumerable
    {
        if (collection == null)
            throw new ValidationException("The collection cannot be null", paramName);

        if (minimumCount < 0)
            throw new ValidationException("Minimum count cannot be negative", nameof(minimumCount));

        // Check if it's an ICollection to efficiently check count
        if (collection is ICollection icollection)
        {
            if (icollection.Count < minimumCount)
                throw new ValidationException($"The collection must have at least {minimumCount} elements", paramName);
        }
        else
        {
            // For other enumerables, we need to count elements
            int count = 0;
            var enumerator = collection.GetEnumerator();
            try
            {
                while (enumerator.MoveNext() && count < minimumCount)
                    count++;
                
                if (count < minimumCount)
                    throw new ValidationException($"The collection must have at least {minimumCount} elements", paramName);
            }
            finally
            {
                if (enumerator is IDisposable disposable)
                    disposable.Dispose();
            }
        }

        return collection;
    }

    /// <summary>
    /// Ensures that a collection has at most the specified number of elements
    /// </summary>
    public static T HasMaximumCount<T>(this T collection, int maximumCount, [CallerArgumentExpression("collection")] string paramName = null!) 
        where T : IEnumerable
    {
        if (collection == null)
            throw new ValidationException("The collection cannot be null", paramName);

        if (maximumCount < 0)
            throw new ValidationException("Maximum count cannot be negative", nameof(maximumCount));

        // Check if it's an ICollection to efficiently check count
        if (collection is ICollection icollection)
        {
            if (icollection.Count > maximumCount)
                throw new ValidationException($"The collection must have at most {maximumCount} elements", paramName);
        }
        else
        {
            // For other enumerables, we need to count elements
            int count = 0;
            var enumerator = collection.GetEnumerator();
            try
            {
                while (enumerator.MoveNext() && count <= maximumCount)
                    count++;
                
                if (count > maximumCount)
                    throw new ValidationException($"The collection must have at most {maximumCount} elements", paramName);
            }
            finally
            {
                if (enumerator is IDisposable disposable)
                    disposable.Dispose();
            }
        }

        return collection;
    }
}