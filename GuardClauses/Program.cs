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
    ArgumentNullException.ThrowIfNull(order);
    ArgumentException.ThrowIfNullOrEmpty(order.CustomerName);
    ArgumentNullException.ThrowIfNull(order.Products);
    ArgumentOutOfRangeException.ThrowIfZero(order.Products.Count);

    Console.WriteLine($"User {order.CustomerName} has ordered:");

    foreach (var product in order.Products)
    {
        Console.WriteLine($"{product}");
    }
}