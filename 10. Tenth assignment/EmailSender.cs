using System.Net;
using System.Net.Mail;
using FluentEmail.Core;
using FluentEmail.Razor;
using FluentEmail.Smtp;

public class EmailSender
{
    const string senderEmail = "barbers.baybg@gmail.com";
    const string senderPassword = "dngd roit xigx pmmk ";

    static EmailSender()
    {
        var sender = new SmtpSender(() => new()
        {
            Host = "smtp.gmail.com",
            Port = 587,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(senderEmail, senderPassword),
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
        });

        Email.DefaultSender = sender;
        Email.DefaultRenderer = new RazorRenderer();
    }

    public async Task SendConfirmationEmailAsync(string recipientEmail, object model)
    {
        var emailTemplate = File.ReadAllText("template.html");

        await Email
            .From(senderEmail)
            .To(recipientEmail)
            .Subject("Confirm email")
            .UsingTemplate(emailTemplate, model)
            .SendAsync();
    }
}
