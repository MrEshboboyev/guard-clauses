using GuardClauses.AdvancedGuards;

namespace GuardClauses;

public class Order
{
    public string CustomerName { get; set; } = string.Empty;
    public List<string> Products { get; set; } = [];
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string Email { get; set; } = string.Empty;
    public DateTime OrderDate { get; set; }
    
    public Order(string customerName, List<string> products, int quantity, decimal price, string email)
    {
        // Using advanced fluent guard clauses
        CustomerName = Guard.For(customerName)
            .NotNull()
            .NotNullOrEmpty()
            .Value;
            
        Products = Guard.For(products)
            .NotNull()
            .Value
            .NotNullOrEmpty()
            .ToList();
            
        Quantity = Guard.For(quantity)
            .NotZeroOrNegative()
            .Value;
            
        Price = Guard.For(price)
            .NotZeroOrNegative()
            .Value;
            
        Email = Guard.For(email)
            .NotNull()
            .NotNullOrEmpty()
            .MatchesRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")
            .Value;
            
        OrderDate = DateTime.UtcNow;
    }
    
    public decimal TotalAmount => Quantity * Price;
}