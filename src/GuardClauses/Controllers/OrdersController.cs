using Microsoft.AspNetCore.Mvc;

namespace GuardClauses.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private static readonly List<Order> Orders = new();
    private static readonly List<Customer> Customers = new();

    [HttpPost]
    public IActionResult CreateOrder([FromBody] OrderRequest request)
    {
        try
        {
            // Validate input using guard clauses
            var customerName = Ensure.NotNullOrEmpty(request.CustomerName);
            var products = Ensure.NotNullOrEmptyList(request.Products);
            var quantity = Ensure.NotZeroOrNegative(request.Quantity);
            var price = Ensure.NotZeroOrNegative(request.Price);
            var email = Ensure.MatchesRegex(Ensure.NotNullOrEmpty(request.Email), @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            // Create order
            var order = new Order(customerName, products.ToList(), quantity, price, email);
            
            // Find or create customer
            var customer = Customers.FirstOrDefault(c => c.Email == email);
            if (customer == null)
            {
                customer = new Customer(customerName, 25, email); // Default age for demo
                Customers.Add(customer);
            }
            
            customer.AddOrder(order);
            Orders.Add(order);

            return CreatedAtAction(nameof(GetOrder), new { id = Orders.Count - 1 }, order);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetOrder(int id)
    {
        try
        {
            var orderId = Ensure.NotNegative(id);
            
            if (orderId >= Orders.Count)
                return NotFound();
                
            return Ok(Orders[orderId]);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpGet]
    public IActionResult GetAllOrders()
    {
        return Ok(Orders);
    }

    [HttpGet("customer/{email}")]
    public IActionResult GetCustomerOrders(string email)
    {
        try
        {
            var customerEmail = Ensure.NotNullOrEmpty(email);
            var customer = Customers.FirstOrDefault(c => c.Email == customerEmail);
            
            if (customer == null)
                return NotFound();
                
            return Ok(customer.Orders);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}

public class OrderRequest
{
    public string CustomerName { get; set; } = string.Empty;
    public List<string> Products { get; set; } = [];
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string Email { get; set; } = string.Empty;
}