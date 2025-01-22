# 🛡️ Guard Clauses in .NET  

This repository provides a comprehensive guide to implementing **guard clauses** in **.NET**. Guard clauses are a powerful tool in defensive programming, ensuring that your code fails fast when encountering invalid input or unexpected conditions.  

In this project, you'll explore:  
1. Using built-in .NET features for guard clauses.  
2. Implementing custom guard clauses tailored to your needs.  
3. Practical examples with **Order** and **Customer** objects in a console application.  

## 🌟 Features  

### Core Concepts  
- **Built-in Guard Clauses**: Using .NET features like `ArgumentNullException`, `ArgumentException`, and `ArgumentOutOfRangeException` for input validation.  
- **Custom Guard Clauses**: Creating reusable, maintainable, and expressive validation methods.  

### Practical Examples  
- **Order Example**: Validates order properties such as quantity and price.  
- **Customer Example**: Ensures customer properties like name and age meet expected constraints.  

## 📂 Repository Structure  

```
📦 GuardClauses  
 ┣ 📂 GuardClauses            # Console application showcasing guard clauses in action  
 ┣ 📂 Tests                 # Unit tests for built-in and custom guard clauses  (coming soon)
```  

## 🛠 Getting Started  

### Prerequisites  
Ensure you have the following installed:  
- .NET Core SDK  
- A modern C# IDE (e.g., Visual Studio or JetBrains Rider)  

### Step 1: Clone the Repository  
```bash  
git clone https://github.com/MrEshboboyev/guard-clauses.git  
cd GuardClauses
```  

### Step 2: Run the Console Application  
```bash  
dotnet run --project GuardClauses
```  

### Step 3: Explore the Code  
Dive into the `Ensure` to see how guard clauses are implemented and used.  

## 📖 Code Highlights  

### Built-In Guard Clauses Example  
```csharp  
static void ProcessOrder(Order order)
{
    Ensure.NotNull(order);
    Ensure.NotNullOrEmpty(order.CustomerName);
    Ensure.NotNullOrEmptyList(order.Products);

    Console.WriteLine($"User {order.CustomerName} has ordered:");

    foreach (var product in order.Products)
    {
        Console.WriteLine($"{product}");
    }
}
```  

### Custom Guard Clause Example  
```csharp  
public static class Ensure
{
    public static void NotNull<T>(T? value, [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (value is null) throw new ArgumentNullException(
            "The value cannot be null",
            paramName);
    }
    
    public static void NotNullOrEmpty(string? value, [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(
            "The string cannot be null nor empty", 
            paramName);
    }
    
    public static void NotNullOrEmptyList<T>(List<T>? list, [CallerArgumentExpression("list")] string? paramName = null)
    {
        if (list is null || list.Count == 0)
        {
            throw new ArgumentException("The list should contain at least 1 item.", paramName);
        }
    }
}


// Usage  
static void ProcessOrder(Order order)
{
    Ensure.NotNull(order);
    Ensure.NotNullOrEmpty(order.CustomerName);
    Ensure.NotNullOrEmptyList(order.Products);

    Console.WriteLine($"User {order.CustomerName} has ordered:");

    foreach (var product in order.Products)
    {
        Console.WriteLine($"{product}");
    }
} 
```  

## 🌐 Practical Use Cases  

### 1. Order Validation  
- Ensure order quantity and price are valid before processing.  

### 2. Customer Validation  
- Validate customer data such as name and age during object instantiation.  

## 🧪 Testing  
The repository includes unit tests for both built-in and custom guard clauses.  

## 🌟 Why Use Guard Clauses?  
1. **Fail Fast**: Identify and handle invalid inputs immediately.  
2. **Readable Code**: Simplify method logic by removing nested validation checks.  
3. **Reusable Logic**: Custom guard clauses make validation consistent and maintainable.  

## 🏗 About the Author  
This project was developed by [MrEshboboyev](https://github.com/MrEshboboyev), a software developer passionate about clean code, defensive programming, and scalable architectures.  

## 📄 License  
This project is licensed under the MIT License. Feel free to use and adapt the code for your own projects.  

## 🔖 Tags  
C#, .NET, Guard Clauses, Defensive Programming, Input Validation, Software Architecture, Clean Code, Error Handling, Console Application, Custom Implementation  

---  

Feel free to suggest additional features or ask questions! 🚀  
