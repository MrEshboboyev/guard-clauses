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
    // ArgumentNullException.ThrowIfNull(order);
    Ensure.NotNull(order, nameof(order));
    
    // ArgumentException.ThrowIfNullOrEmpty(order.CustomerName);
    Ensure.NotNullOrEmpty(order.CustomerName, nameof(order.CustomerName));
    
    // ArgumentNullException.ThrowIfNull(order.Products);
    Ensure.NotNullOrEmptyList(order.Products, nameof(order.Products));

    Console.WriteLine($"User {order.CustomerName} has ordered:");

    foreach (var product in order.Products)
    {
        Console.WriteLine($"{product}");
    }
}