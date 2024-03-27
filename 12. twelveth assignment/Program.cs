var user1 = new User
{
    Name = "Gosho",
    Age = 20,
    PhoneNumber = "0895105609",
    Email = "gkerkelov03@abv.bg",
};

var user2 = new User
{
    Name = "Pesho",
    Age = 19,
    PhoneNumber = "0895106704",
    Email = "pesho03@abv.bg",
};

var user3 = new User
{
    Name = "Stamo",
    Age = 21,
    PhoneNumber = "0895000703",
    Email = "stamo03@abv.bg",
};

var emailSender = new EmailSender();
var pushNotificationsSender = new PushNotificationSender();
var SmsSender = new SmsSender();

var emailsChannel = new Channel(emailSender);
emailsChannel.AddUser(user1);
emailsChannel.AddUser(user2);
emailsChannel.Broadcast(from: user1, "Broadcast1: Hello everyone, how are you doing?");
emailsChannel._sender.SendNotification(from: user2, to: user1, content: "Hello, how are you?");

var smsChannel = new Channel(SmsSender);
smsChannel.AddUser(user2);
smsChannel.AddUser(user3);
smsChannel.Broadcast(from: user3, "Broadcast2: Hello everyone, how are you doing?");
smsChannel._sender.SendNotification(from: user2, to: user3, content: "Hello, how are you?");

var pushNotificationsChannel = new Channel(pushNotificationsSender);
pushNotificationsChannel.AddUser(user1);
pushNotificationsChannel.AddUser(user3);
pushNotificationsChannel.Broadcast(from: user3, "Broadcast3: Hello everyone, how are you doing?");
pushNotificationsChannel._sender.SendNotification(from: user1, to: user3, content: "Hello, how are you?");
