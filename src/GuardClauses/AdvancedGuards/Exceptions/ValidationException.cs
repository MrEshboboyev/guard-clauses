namespace GuardClauses.AdvancedGuards.Exceptions;

/// <summary>
/// Represents errors that occur during validation
/// </summary>
public class ValidationException : Exception
{
    /// <summary>
    /// Gets the name of the parameter that caused the exception
    /// </summary>
    public string? ParamName { get; }

    /// <summary>
    /// Initializes a new instance of the ValidationException class
    /// </summary>
    public ValidationException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the ValidationException class with a specified error message
    /// </summary>
    public ValidationException(string message) : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the ValidationException class with a specified error message
    /// and a reference to the inner exception that is the cause of this exception
    /// </summary>
    public ValidationException(string message, Exception innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the ValidationException class with a specified error message
    /// and the name of the parameter that caused the exception
    /// </summary>
    public ValidationException(string message, string paramName) : base(message)
    {
        ParamName = paramName;
    }

    /// <summary>
    /// Initializes a new instance of the ValidationException class with a specified error message,
    /// the name of the parameter that caused the exception, and a reference to the inner exception
    /// that is the cause of this exception
    /// </summary>
    public ValidationException(string message, string paramName, Exception innerException) : base(message, innerException)
    {
        ParamName = paramName;
    }
}