public class Customer : IOrderObserver
{
    public string Name { get; }

    public Customer(string name) => Name = name;

    public void HandleOrderChange(Order order)
        => Console.WriteLine($"Notification for customer {Name}: Order {order.OrderId} status changed to {order.Status}");
}
