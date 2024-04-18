using System.Net;
using System.Net.Mail;

public class EmailSender : IDisposable
{
    private const string _senderEmail = "barbers.baybg@gmail.com";
    private const string _senderEmailPassword = "dngd roit xigx pmmk";

    private readonly SmtpClient _smtpClient = new()
    {
        Host = "smtp.gmail.com",
        Port = 587,
        UseDefaultCredentials = false,
        Credentials = new NetworkCredential(_senderEmail, _senderEmailPassword),
        EnableSsl = true,
        DeliveryMethod = SmtpDeliveryMethod.Network,
    };

    public void SendThankYouEmail(string recipientEmail, string name)
    {
        var content = $"Hello {name}, thank you very much for subscribing to our email campaign.";
        var subject = "Thank you";

        var emailToSend = new MailMessage(_senderEmail, recipientEmail, subject, content);

        _smtpClient.Send(emailToSend);
    }

    public void Dispose() => _smtpClient.Dispose();
}