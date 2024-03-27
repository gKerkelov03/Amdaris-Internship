public class EmailSender : INotificationSender
{
    public void SendNotification(User from, User to, string content)
    {
        Console.WriteLine($"Sending email from {from.Name} to {to.Name} with contents: '{content}'");
    }
}