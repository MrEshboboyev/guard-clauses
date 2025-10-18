using GuardClauses.AdvancedGuards;
using GuardClauses.AdvancedGuards.Exceptions;
using GuardClauses.AdvancedGuards.Attributes;

namespace GuardClauses.AdvancedGuards.Examples;

/// <summary>
/// Examples demonstrating advanced guard clause usage
/// </summary>
public class AdvancedGuardExamples
{
    /// <summary>
    /// Example showing fluent API usage
    /// </summary>
    public static void FluentApiExample()
    {
        Console.WriteLine("=== Fluent API Example ===");
        
        try
        {
            // Using the fluent API
            var email = Guard.For("user@example.com")
                .NotNull()
                .NotNullOrEmpty()
                .MatchesRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")
                .Value;
                
            var age = Guard.For(25)
                .NotNegative()
                .InRange(0, 120)
                .Value;
                
            var amount = Guard.For(99.99m)
                .NotZeroOrNegative()
                .Satisfies(x => x <= 10000m, "Amount cannot exceed $10,000")
                .Value;
                
            Console.WriteLine($"Validated email: {email}");
            Console.WriteLine($"Validated age: {age}");
            Console.WriteLine($"Validated amount: ${amount}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Validation failed: {ex.Message}");
        }
    }
    
    /// <summary>
    /// Example showing custom exception usage
    /// </summary>
    public static void CustomExceptionExample()
    {
        Console.WriteLine("\n=== Custom Exception Example ===");
        
        try
        {
            // Using the fluent API with custom exceptions
            var email = GuardWithCustomExceptions.For("invalid-email")
                .NotNull()
                .NotNullOrEmpty()
                .MatchesRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")
                .Value;
        }
        catch (ValidationException ex)
        {
            Console.WriteLine($"Validation failed with custom exception: {ex.Message}");
            Console.WriteLine($"Parameter name: {ex.ParamName}");
        }
    }
    
    /// <summary>
    /// Example showing collection guard usage
    /// </summary>
    public static void CollectionGuardExample()
    {
        Console.WriteLine("\n=== Collection Guard Example ===");
        
        try
        {
            var items = new List<string> { "item1", "item2", "item3" };
            
            // Using collection extension methods
            var validatedItems = items
                .NotNullOrEmpty()
                .HasMinimumCount(2)
                .HasMaximumCount(5);
                
            Console.WriteLine($"Validated collection with {validatedItems.Count} items");
        }
        catch (ValidationException ex)
        {
            Console.WriteLine($"Collection validation failed: {ex.Message}");
        }
    }
    
    /// <summary>
    /// Example showing composite guard usage
    /// </summary>
    public static void CompositeGuardExample()
    {
        Console.WriteLine("\n=== Composite Guard Example ===");
        
        try
        {
            var email = CompositeGuards.ValidEmail("user@example.com");
            var age = CompositeGuards.ValidAge(25);
            var amount = CompositeGuards.ValidAmount(99.99m);
            var phone = CompositeGuards.ValidPhoneNumber("+1 (555) 123-4567");
            
            Console.WriteLine($"Validated email: {email}");
            Console.WriteLine($"Validated age: {age}");
            Console.WriteLine($"Validated amount: ${amount}");
            Console.WriteLine($"Validated phone: {phone}");
        }
        catch (ValidationException ex)
        {
            Console.WriteLine($"Composite validation failed: {ex.Message}");
        }
    }
    
    /// <summary>
    /// Example showing async guard usage
    /// </summary>
    public static async Task AsyncGuardExample()
    {
        Console.WriteLine("\n=== Async Guard Example ===");
        
        try
        {
            // Simulate async validation (e.g., checking if user exists in database)
            var userId = await AsyncGuards.SatisfiesAsync(
                123, 
                async id => 
                {
                    // Simulate async database check
                    await Task.Delay(10);
                    return id > 0;
                },
                "User ID must be positive");
                
            Console.WriteLine($"Validated user ID: {userId}");
        }
        catch (ValidationException ex)
        {
            Console.WriteLine($"Async validation failed: {ex.Message}");
        }
    }
    
    /// <summary>
    /// Example showing attribute-based validation
    /// </summary>
    public static void AttributeBasedValidationExample()
    {
        Console.WriteLine("\n=== Attribute-Based Validation Example ===");
        
        try
        {
            // Create a customer with valid data
            var validCustomer = new ValidatedCustomer("John Doe", 30, "john@example.com");
            validCustomer.Validate();
            Console.WriteLine($"Valid customer: {validCustomer.Name}, {validCustomer.Age}");
            
            // Create a customer with invalid data
            var invalidCustomer = new ValidatedCustomer("", -5, "invalid-email");
            invalidCustomer.Validate();
        }
        catch (ValidationException ex)
        {
            Console.WriteLine($"Attribute-based validation failed: {ex.Message}");
            Console.WriteLine($"Property name: {ex.ParamName}");
        }
    }
    
    /// <summary>
    /// Example showing extension methods for common .NET types
    /// </summary>
    public static void ExtensionMethodsExample()
    {
        Console.WriteLine("\n=== Extension Methods Example ===");
        
        try
        {
            // String extensions
            var email = "user@example.com"
                .NotNullOrWhiteSpace()
                .HasMinimumLength(5)
                .HasMaximumLength(100)
                .ValidEmail();
                
            // Numeric extensions
            var age = 25.Positive().Between(18, 65);
            var amount = 99.99m.NonNegative().MaxDecimalPlaces(2);
            var evenNumber = 10.Even();
            
            // DateTime extensions
            var futureDate = DateTime.Now.AddDays(10).NotInPast().Weekday();
            
            Console.WriteLine($"Validated email: {email}");
            Console.WriteLine($"Validated age: {age}");
            Console.WriteLine($"Validated amount: ${amount}");
            Console.WriteLine($"Validated even number: {evenNumber}");
            Console.WriteLine($"Validated future date: {futureDate}");
        }
        catch (ValidationException ex)
        {
            Console.WriteLine($"Extension method validation failed: {ex.Message}");
        }
    }
    
    /// <summary>
    /// Run all examples
    /// </summary>
    public static async Task RunAllExamples()
    {
        FluentApiExample();
        CustomExceptionExample();
        CollectionGuardExample();
        CompositeGuardExample();
        await AsyncGuardExample();
        AttributeBasedValidationExample();
        ExtensionMethodsExample();
    }
}