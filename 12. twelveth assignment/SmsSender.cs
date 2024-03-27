public class SmsSender : INotificationSender
{
    public void SendNotification(User from, User to, string content)
    {
        Console.WriteLine($"Sending sms from {from.Name} to {to.Name} with contents: '{content}'");
    }
}