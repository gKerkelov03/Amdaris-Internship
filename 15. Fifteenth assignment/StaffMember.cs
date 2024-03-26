
// public class Customer : IObserver
// {
//     public string Name { get; private set; }

//     public Customer(string name)
//     {
//         Name = name;
//     }

//     public void Update(Order order)
//     {
//         Console.WriteLine($"Notification for customer {Name}: Order {order.OrderId} status changed to {order.Status}");
//     }
// }

public class StaffMember : IOrderObserver
{
    public string Name { get; }

    public StaffMember(string name) => Name = name;

    public void HandleOrderChange(Order order)
        => Console.WriteLine($"Notification for staff member {Name}: Order {order.OrderId} status changed to {order.Status}");
}
