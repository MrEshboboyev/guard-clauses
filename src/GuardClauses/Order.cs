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
        CustomerName = Ensure.NotNullOrEmpty(customerName);
        Products = new List<string>(Ensure.NotNullOrEmptyList(products));
        Quantity = Ensure.NotZeroOrNegative(quantity);
        Price = Ensure.NotZeroOrNegative(price);
        Email = Ensure.MatchesRegex(Ensure.NotNullOrEmpty(email), @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        OrderDate = DateTime.UtcNow;
    }
    
    public decimal TotalAmount => Quantity * Price;
}