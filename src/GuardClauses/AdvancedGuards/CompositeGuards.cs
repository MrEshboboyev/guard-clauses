using System.Runtime.CompilerServices;
using GuardClauses.AdvancedGuards.Exceptions;

namespace GuardClauses.AdvancedGuards;

/// <summary>
/// Provides composite guard clause validations for complex business rules
/// </summary>
public static class CompositeGuards
{
    /// <summary>
    /// Validates that a person's age is valid according to business rules
    /// </summary>
    public static int ValidAge(
        int age, 
        int minimumAge = 0, 
        int maximumAge = 120,
        [CallerArgumentExpression("age")] string paramName = null!)
    {
        if (age < minimumAge || age > maximumAge)
            throw new ValidationException($"Age must be between {minimumAge} and {maximumAge}", paramName);
        
        return age;
    }

    /// <summary>
    /// Validates that an email address is valid
    /// </summary>
    public static string ValidEmail(
        string email,
        [CallerArgumentExpression("email")] string paramName = null!)
    {
        if (string.IsNullOrEmpty(email))
            throw new ValidationException("Email cannot be null or empty", paramName);
            
        if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            throw new ValidationException("Email address is not valid", paramName);
            
        return email;
    }

    /// <summary>
    /// Validates that a monetary amount is valid
    /// </summary>
    public static decimal ValidAmount(
        decimal amount,
        decimal minimumAmount = 0,
        [CallerArgumentExpression("amount")] string paramName = null!)
    {
        if (amount < minimumAmount)
            throw new ValidationException($"Amount cannot be less than {minimumAmount}", paramName);
            
        // Check for too many decimal places (more than 2)
        if (Math.Round(amount, 2) != amount)
            throw new ValidationException("Amount cannot have more than 2 decimal places", paramName);
            
        return amount;
    }

    /// <summary>
    /// Validates that a phone number is valid
    /// </summary>
    public static string ValidPhoneNumber(
        string phoneNumber,
        [CallerArgumentExpression("phoneNumber")] string paramName = null!)
    {
        if (string.IsNullOrEmpty(phoneNumber))
            throw new ValidationException("Phone number cannot be null or empty", paramName);
            
        // Remove common formatting characters
        string cleanedNumber = System.Text.RegularExpressions.Regex.Replace(phoneNumber, @"[\s\-\(\)\+]", "");
        
        // Check if it contains only digits and is of reasonable length
        if (!System.Text.RegularExpressions.Regex.IsMatch(cleanedNumber, @"^\d{7,15}$"))
            throw new ValidationException("Phone number is not valid", paramName);
            
        return phoneNumber;
    }
}