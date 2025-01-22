using GuardClauses;

Order order = new()
{
    CustomerName = "Stefan",
    Products = ["apple", "juice", "bread"]
};

ProcessOrder(order);

Console.WriteLine("Hello, World!");

static void ProcessOrder(Order order)
{
    if (order is null)
    {
        throw new ArgumentException("The order is required.", nameof(order));
    }

    if (string.IsNullOrEmpty(order.CustomerName))
    {
        throw new ArgumentException("The Customer Name is required.", nameof(order.CustomerName));
    }

    Console.WriteLine($"User {order.CustomerName} has ordered:");

    if (order.Products is null || order.Products.Count == 0)
    {
        throw new ArgumentException("The order should contain at least 1 product", nameof(order.Products));
    }

    foreach (var product in order.Products)
    {
        Console.WriteLine($"{product}");
    }
}

