
public class Channel : INotificationChannel
{
    private List<User> _users = new List<User>();
    public IEnumerable<User> Users { get => _users; }

    public INotificationSender _sender;

    public Channel(INotificationSender sender) => _sender = sender;

    public void AddUser(User user) => _users.Add(user);

    public void RemoveUser(User user) => _users.Remove(user);

    public void Broadcast(User from, string content)
        => _users.ForEach(user =>
        {
            if (user.Email != from.Email)
            {
                _sender.SendNotification(from, user, content);
            }
        });

    public void SendTo(User from, User to, string content)
    {
        var isTheSenderInTheChannel = _users.Any(user => user.Email == from.Email);
        var isTheRecipientInTheChannel = _users.Any(user => user.Email == to.Email);

        if (!isTheRecipientInTheChannel || !isTheSenderInTheChannel)
        {
            throw new ArgumentException("Only users members of the channel can send and receive notifications");
        }

        _sender.SendNotification(from, to, content);
    }
}