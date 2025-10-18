# 🛡️ Advanced Guard Clauses in .NET

This repository demonstrates the **true potential and power of guard clauses** in **.NET**, showcasing how they can be used to create robust, maintainable, and professional-grade applications. Guard clauses are essential for defensive programming, ensuring that your code fails fast when encountering invalid input or unexpected conditions.

Unlike basic implementations, this project shows how guard clauses can be leveraged in a full-featured web API with Swagger documentation, demonstrating their real-world applicability, and includes advanced patterns like fluent APIs, custom exceptions, attribute-based validation, and extension methods.

## 🌟 Features

### Comprehensive Guard Clause Library
- **Null Checks**: `NotNull<T>()` for reference types
- **String Validation**: `NotNullOrEmpty()` for strings
- **Collection Validation**: `NotNullOrEmptyList<T>()` for collections
- **Range Validation**: `InRange<T>()` for comparable values
- **Numeric Validation**: `NotNegative()`, `NotZeroOrNegative()` for numeric types
- **Pattern Matching**: `MatchesRegex()` for string pattern validation
- **Default Value Checks**: `NotDefault<T>()` for value types

### Advanced Guard Clause Patterns
- **Fluent API**: Chain multiple validations together for a clean, readable syntax
- **Custom Exceptions**: Use domain-specific exceptions for better error handling
- **Attribute-Based Validation**: Decorate properties with validation attributes
- **Async Guard Clauses**: Validate data asynchronously for external service checks
- **Composite Guards**: Complex business rule validations
- **Extension Methods**: Extend common .NET types with guard clause functionality

### Professional Web API Implementation
- **RESTful API Design**: Clean controllers with proper HTTP status codes
- **Swagger Integration**: Full API documentation with NSwag
- **Real-World Examples**: Order and Customer management scenarios
- **Comprehensive Error Handling**: Consistent error responses using guard clauses

### Advanced Concepts
- **Return Values**: Guard clauses return validated values for fluent APIs
- **Generic Constraints**: Type-safe validation with generics
- **Expression-Based Parameter Names**: Automatic parameter name detection
- **Performance Optimized**: Minimal overhead with maximum protection

## 📂 Repository Structure

```
📦 GuardClauses
 ┣ 📂 AdvancedGuards              # Advanced guard clause implementations
 ┃ ┣ 📂 Attributes               # Attribute-based validation
 ┃ ┣ 📂 Examples                 # Examples of advanced guard clause usage
 ┃ ┣ 📂 Exceptions               # Custom exception types
 ┃ ┣ 📜 AsyncGuards.cs          # Asynchronous guard clauses
 ┃ ┣ 📜 CollectionGuards.cs      # Collection extension methods
 ┃ ┣ 📜 CompositeGuards.cs       # Complex business rule validations
 ┃ ┣ 📜 DateTimeGuards.cs        # DateTime extension methods
 ┃ ┣ 📜 FluentGuard.cs           # Fluent API implementation
 ┃ ┣ 📜 FluentGuardWithCustomExceptions.cs # Fluent API with custom exceptions
 ┃ ┣ 📜 Guard.cs                # Factory class for fluent guards
 ┃ ┣ 📜 GuardWithCustomExceptions.cs # Factory class for fluent guards with custom exceptions
 ┃ ┣ 📜 NumericGuards.cs         # Numeric extension methods
 ┃ ┣ 📜 StringGuards.cs          # String extension methods
 ┃ ┗ 📜 ObjectValidator.cs       # Attribute-based object validator
 ┣ 📂 Controllers                # REST API controllers demonstrating guard clause usage
 ┣ 📂 UnitTests                 # NUnit tests for guard clauses
 ┣ 📜 Ensure.cs                 # Basic guard clause implementations
 ┣ 📜 Order.cs                  # Order model with validation in constructor
 ┣ 📜 Customer.cs               # Customer model with validation in constructor
 ┣ 📜 Program.cs                # Web application entry point with Swagger configuration
 ┣ 📜 GuardClauses.csproj       # .NET web API project with NSwag package reference
 ┗ 📜 TestGuardClauses.cs       # Console application to test guard clause functionality
```

## 🛠 Getting Started

### Prerequisites
Ensure you have the following installed:
- .NET 9.0 SDK or later
- A modern C# IDE (e.g., Visual Studio, Visual Studio Code, or JetBrains Rider)

### Step 1: Clone the Repository
```bash
git clone https://github.com/MrEshboboyev/guard-clauses.git
cd guard-clauses
```

### Step 2: Run the Web API
```bash
dotnet run --project src/GuardClauses
```

### Step 3: Access the API Documentation
Navigate to `http://localhost:5000/swagger` to view the interactive API documentation.

### Step 4: Run the Advanced Guard Clauses Demo
```bash
dotnet run --project GuardClauses.Demo
```

### Step 5: Run Unit Tests
```bash
dotnet test
```

## 📖 Code Highlights

### Advanced Fluent Guard Clause Implementation
```csharp
// Fluent API with method chaining
var email = Guard.For("user@example.com")
    .NotNull()
    .NotNullOrEmpty()
    .MatchesRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")
    .Value;

var age = Guard.For(25)
    .NotNegative()
    .InRange(0, 120)
    .Value;
```

### Attribute-Based Validation
```csharp
public class ValidatedCustomer
{
    [NotNull]
    [NotEmpty]
    public string Name { get; set; } = string.Empty;

    [Range(13, 120)]
    public int Age { get; set; }

    [NotNull]
    [NotEmpty]
    public string Email { get; set; } = string.Empty;
}

// Validate the object
var customer = new ValidatedCustomer("John Doe", 30, "john@example.com");
ObjectValidator.Validate(customer);
```

### Extension Methods for Common Types
```csharp
// String extensions
var email = "user@example.com"
    .NotNullOrWhiteSpace()
    .HasMinimumLength(5)
    .HasMaximumLength(100)
    .ValidEmail();

// Numeric extensions
var age = 25.Positive().Between(18, 65);
var amount = 99.99m.NonNegative().MaxDecimalPlaces(2);

// DateTime extensions
var futureDate = DateTime.Now.AddDays(10).NotInPast().Weekday();
```

### Async Guard Clauses
```csharp
// Validate data asynchronously (e.g., checking if user exists in database)
var userId = await AsyncGuards.SatisfiesAsync(
    123, 
    async id => 
    {
        // Simulate async database check
        await Task.Delay(10);
        return id > 0;
    },
    "User ID must be positive");
```

### Traditional Guard Clause Implementation
```csharp
public static class Ensure
{
    public static T NotNull<T>(T? value, [CallerArgumentExpression("value")] string? paramName = null) where T : class
    {
        if (value is null) throw new ArgumentNullException(
            paramName, "The value cannot be null");
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
```

### Model Validation with Guard Clauses
```csharp
public class Customer
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Email { get; set; } = string.Empty;
    
    public Customer(string name, int age, string email)
    {
        // Using advanced fluent guard clauses
        Name = Guard.For(name)
            .NotNull()
            .NotNullOrEmpty()
            .Value;
            
        Age = Guard.For(age)
            .NotNegative()
            .InRange(13, 120)
            .Value;
            
        Email = Guard.For(email)
            .NotNull()
            .NotNullOrEmpty()
            .MatchesRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")
            .Value;
    }
}
```

### Controller Implementation with Guard Clauses
```csharp
[HttpPost]
public IActionResult CreateCustomer([FromBody] CustomerRequest request)
{
    try
    {
        // Validate input using guard clauses
        var name = Ensure.NotNullOrEmpty(request.Name);
        var age = Ensure.InRange(request.Age, 13, 120);
        var email = Ensure.MatchesRegex(Ensure.NotNullOrEmpty(request.Email), @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        // Create customer
        var customer = new Customer(name, age, email);
        // ... rest of implementation
        
        return CreatedAtAction(nameof(GetCustomer), new { email = customer.Email }, customer);
    }
    catch (Exception ex)
    {
        return BadRequest(new { error = ex.Message });
    }
}
```

## 🌐 Practical Use Cases

### 1. Input Validation
- Ensure API inputs meet business requirements before processing
- Prevent invalid data from entering your domain models

### 2. Domain Model Integrity
- Guarantee that objects are always in a valid state
- Fail-fast behavior prevents corrupted data propagation

### 3. API Error Handling
- Consistent error responses with meaningful messages
- Reduced boilerplate validation code

### 4. Business Rule Enforcement
- Complex validations that span multiple properties
- Attribute-based validation for declarative rules

### 5. Asynchronous Validation
- External service checks (e.g., database existence)
- Third-party API validations

## 🧪 Testing Guard Clauses

All guard clauses are designed to be easily testable. Here's an example of how you could test the `NotNull` guard clause:

```csharp
[Test]
public void NotNull_WhenValueIsNull_ThrowsArgumentNullException()
{
    string? value = null;
    
    Assert.Throws<ArgumentNullException>(() => Ensure.NotNull(value));
}

[Test]
public void NotNull_WhenValueIsNotNull_ReturnsValue()
{
    string value = "test";
    
    var result = Ensure.NotNull(value);
    
    Assert.AreEqual(value, result);
}
```

We've also included comprehensive unit tests in the `GuardClauses.UnitTests` project that validate all guard clauses with various input scenarios, including the advanced patterns.

## 🌟 Benefits of Using Guard Clauses

1. **Fail Fast**: Identify and handle invalid inputs immediately, preventing issues from propagating through your system.
2. **Readable Code**: Simplify method logic by removing nested validation checks, making code easier to understand.
3. **Reusable Logic**: Custom guard clauses make validation consistent and maintainable across your entire application.
4. **Professional Quality**: Demonstrate craftsmanship through defensive programming practices that protect against runtime errors.
5. **Self-Documenting**: Guard clauses serve as executable documentation of your method's preconditions.
6. **Flexible**: Support for fluent APIs, custom exceptions, attributes, and extension methods allows you to choose the right pattern for each scenario.

## 🏗 About the Author

This project was developed by [MrEshboboyev](https://github.com/MrEshboboyev), a software developer passionate about clean code, defensive programming, and scalable architectures.

## 📄 License

This project is licensed under the MIT License. Feel free to use and adapt the code for your own projects.

## 🔖 Tags

C#, .NET, Guard Clauses, Defensive Programming, Input Validation, Software Architecture, Clean Code, Error Handling, Web API, REST, Swagger, NSwag, Unit Testing, Fluent API

---

Feel free to suggest additional features or ask questions! 🚀