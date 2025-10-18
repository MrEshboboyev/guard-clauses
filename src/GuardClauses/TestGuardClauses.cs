using System;
using System.Collections.Generic;

namespace GuardClauses;

public class TestGuardClauses
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Testing Guard Clauses Implementation");
        Console.WriteLine("====================================");
        
        // Test NotNull
        try
        {
            string? testString = null;
            Ensure.NotNull(testString);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"✓ NotNull test passed: {ex.Message}");
        }
        
        // Test NotNullOrEmpty
        try
        {
            string? testString = "";
            Ensure.NotNullOrEmpty(testString);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"✓ NotNullOrEmpty test passed: {ex.Message}");
        }
        
        // Test NotNullOrEmptyList
        try
        {
            List<string>? testList = new List<string>();
            Ensure.NotNullOrEmptyList(testList);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"✓ NotNullOrEmptyList test passed: {ex.Message}");
        }
        
        // Test NotNegative
        try
        {
            int negativeValue = -5;
            Ensure.NotNegative(negativeValue);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"✓ NotNegative test passed: {ex.Message}");
        }
        
        // Test InRange
        try
        {
            int age = 150;
            Ensure.InRange(age, 0, 120);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"✓ InRange test passed: {ex.Message}");
        }
        
        // Test successful validations
        try
        {
            string validString = "Hello World";
            var result = Ensure.NotNullOrEmpty(validString);
            Console.WriteLine($"✓ NotNullOrEmpty successful: {result}");
            
            List<string> validList = new List<string> { "item1", "item2" };
            var listResult = Ensure.NotNullOrEmptyList(validList);
            Console.WriteLine($"✓ NotNullOrEmptyList successful: {listResult.Count} items");
            
            int positiveValue = 10;
            var intResult = Ensure.NotNegative(positiveValue);
            Console.WriteLine($"✓ NotNegative successful: {intResult}");
            
            int validAge = 25;
            var ageResult = Ensure.InRange(validAge, 0, 120);
            Console.WriteLine($"✓ InRange successful: {ageResult}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"✗ Unexpected error: {ex.Message}");
        }
        
        // Test model creation
        try
        {
            var customer = new Customer("John Doe", 30, "john@example.com");
            Console.WriteLine($"✓ Customer created successfully: {customer.Name}, {customer.Age}");
            
            var order = new Order("John Doe", new List<string> { "Product 1", "Product 2" }, 2, 15.99m, "john@example.com");
            Console.WriteLine($"✓ Order created successfully: {order.CustomerName}, {order.Quantity} items, ${order.TotalAmount}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"✗ Model creation failed: {ex.Message}");
        }
        
        Console.WriteLine("\nAll tests completed!");
    }
}