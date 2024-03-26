Console.Write("Enter your email: ");
var email = Console.ReadLine();

Console.Write("Enter your name: ");
var name = Console.ReadLine();

var emailSender = new EmailSender();
var model = new { Name = name };

await emailSender.SendConfirmationEmailAsync(email, model);
Console.WriteLine("Email sent successfully");