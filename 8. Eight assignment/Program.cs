var users = new List<User>
{
    new User
    {
        Name = "Gosho",
        Age = 20,
        Password = "password1",
        Email = "gosho@abv.bg"
    },
    new User
    {
        Name = "Mitko",
        Age = 21,
        Password = "password2",
        Email = "mitko@abv.bg"
    },
    new User
    {
        Name = "Stancho",
        Age = 17,
        Password = "password3",
        Email = "stancho@abv.bg"
    },
};

UserPredicate isGoshoPredicate = (user) => user.Name == "Gosho";
Func<User, bool> isPasswordStrongPredicate = (user) => true;
UserPredicate isAdultPredicate = delegate (User user)
{
    return user.Age >= 18;
};
Action<User> printUserAction = delegate (User user)
{
    Console.WriteLine(user.Name);
};

var usersWithStrongPassword = users.Where(isPasswordStrongPredicate);
var modifiedUsers = users.Select(user => new User
{
    Name = $"{user.Name} {user.Name}v",
    Password = user.Password.Substring(0, user.Password.Length - 1),
    Age = user.Age,
    Email = user.Email
});

Console.WriteLine("Adult users: ");
modifiedUsers.IterateOver(isAdultPredicate, printUserAction);
Console.WriteLine();
Console.WriteLine("Users with strong password: ");
usersWithStrongPassword.IterateOver(isGoshoPredicate, printUserAction);

public delegate bool UserPredicate(User user);
