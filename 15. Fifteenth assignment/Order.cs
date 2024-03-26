public class Order
{
    public string OrderId { get; }
    public OrderStatus Status { get; private set; }
    private List<IOrderObserver> _subscribers;

    public Order(string orderId, IEnumerable<IOrderObserver> subscribers)
    {
        OrderId = orderId;
        _subscribers = subscribers.ToList();
        UpdateStatus(OrderStatus.JustPlaced);
    }

    public void Subscribe(IOrderObserver observer)
        => _subscribers.Add(observer);

    public void Unsubscribe(IOrderObserver observer)
        => _subscribers.Remove(observer);

    public void Broadcast()
    {
        foreach (var observer in _subscribers)
        {
            observer.HandleOrderChange(this);
        }
    }

    public void UpdateStatus(OrderStatus status)
    {
        Status = status;
        Broadcast();
    }
}
