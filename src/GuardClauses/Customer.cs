using System.Text.Json.Serialization;
using GuardClauses.AdvancedGuards;

namespace GuardClauses;

public class Customer
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Email { get; set; } = string.Empty;
    public List<Order> Orders { get; set; } = [];
    
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
            
        Orders = [];
    }
    
    public void AddOrder(Order order)
    {
        Guard.For(order).NotNull();
        Orders.Add(order);
    }
    
    [JsonIgnore]
    public decimal TotalSpent => Orders.Sum(o => o.TotalAmount);
}