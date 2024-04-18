using System.Net.Mail;

Console.Write("Enter your email: ");
var recipientEmail = Console.ReadLine();

Console.Write("Enter your name: ");
var clientName = Console.ReadLine();

var emailSender = new EmailSender();

try
{
    emailSender.SendThankYouEmail(recipientEmail, clientName);
    Console.WriteLine("Email sent successfully");
}
catch (SmtpException ex)
{
    Console.WriteLine(ex.ToString());
}
finally
{
    emailSender.Dispose();
}