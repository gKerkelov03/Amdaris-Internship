public class PushNotificationSender : INotificationSender
{
    public void SendNotification(User from, User to, string content)
    {
        Console.WriteLine($"Sending push notification from {from.Name} to {to.Name} with contents: '{content}'");
    }
}