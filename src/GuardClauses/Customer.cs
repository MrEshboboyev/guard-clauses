using System.Text.Json.Serialization;

namespace GuardClauses;

public class Customer
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Email { get; set; } = string.Empty;
    public List<Order> Orders { get; set; } = [];
    
    public Customer(string name, int age, string email)
    {
        Name = Ensure.NotNullOrEmpty(name);
        Age = Ensure.InRange(age, 13, 120);
        Email = Ensure.MatchesRegex(Ensure.NotNullOrEmpty(email), @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        Orders = [];
    }
    
    public void AddOrder(Order order)
    {
        Ensure.NotNull(order);
        Orders.Add(order);
    }
    
    [JsonIgnore]
    public decimal TotalSpent => Orders.Sum(o => o.TotalAmount);
}