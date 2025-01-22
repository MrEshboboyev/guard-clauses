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
    if (order is not null)
    {
        if (string.IsNullOrEmpty(order.CustomerName))
        {
            Console.WriteLine($"User {order.CustomerName} ordered:");
        }
        else
        {
            throw new ArgumentException("The Customer Name is required.", nameof(order.CustomerName));
        }

        if (order.Products is not null && order.Products.Count > 0)
        {
            foreach (var product in order.Products)
            {
                Console.WriteLine($"{product}");
            }
        }
        else
        {
            throw new ArgumentException("The order should contain at least 1 product", nameof(order.Products));
        }
    }
    else
    {
        throw new ArgumentException("The order is required", nameof(order));
    }
}
