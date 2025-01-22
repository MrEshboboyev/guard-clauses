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
    Ensure.NotNull(order);
    Ensure.NotNullOrEmpty(order.CustomerName);
    Ensure.NotNullOrEmptyList(order.Products);

    Console.WriteLine($"User {order.CustomerName} has ordered:");

    foreach (var product in order.Products)
    {
        Console.WriteLine($"{product}");
    }
}