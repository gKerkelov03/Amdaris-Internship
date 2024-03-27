public interface INotificationChannel
{
    IEnumerable<User> Users { get; }

    void AddUser(User user);

    void RemoveUser(User user);

    void Broadcast(User from, string content);

    void SendTo(User from, User to, string content);
}