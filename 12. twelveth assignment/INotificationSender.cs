public interface INotificationSender
{
    void SendNotification(User from, User to, string content);
}