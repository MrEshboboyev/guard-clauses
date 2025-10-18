using Microsoft.AspNetCore.Mvc;

namespace GuardClauses.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private static readonly List<Customer> Customers = new();

    [HttpPost]
    public IActionResult CreateCustomer([FromBody] CustomerRequest request)
    {
        try
        {
            // Validate input using guard clauses
            var name = Ensure.NotNullOrEmpty(request.Name);
            var age = Ensure.InRange(request.Age, 13, 120);
            var email = Ensure.MatchesRegex(Ensure.NotNullOrEmpty(request.Email), @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            // Check if customer already exists
            if (Customers.Any(c => c.Email == email))
            {
                return Conflict(new { error = "Customer with this email already exists." });
            }

            // Create customer
            var customer = new Customer(name, age, email);
            Customers.Add(customer);

            return CreatedAtAction(nameof(GetCustomer), new { email = customer.Email }, customer);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpGet("{email}")]
    public IActionResult GetCustomer(string email)
    {
        try
        {
            var customerEmail = Ensure.NotNullOrEmpty(email);
            var customer = Customers.FirstOrDefault(c => c.Email == customerEmail);
            
            if (customer == null)
                return NotFound();
                
            return Ok(customer);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpGet]
    public IActionResult GetAllCustomers()
    {
        return Ok(Customers);
    }

    [HttpPut("{email}/update-age")]
    public IActionResult UpdateCustomerAge(string email, [FromBody] UpdateAgeRequest request)
    {
        try
        {
            var customerEmail = Ensure.NotNullOrEmpty(email);
            var newAge = Ensure.InRange(request.NewAge, 13, 120);
            
            var customer = Customers.FirstOrDefault(c => c.Email == customerEmail);
            if (customer == null)
                return NotFound();
                
            customer.Age = newAge;
            return Ok(customer);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}

public class CustomerRequest
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Email { get; set; } = string.Empty;
}

public class UpdateAgeRequest
{
    public int NewAge { get; set; }
}