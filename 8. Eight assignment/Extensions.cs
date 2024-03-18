
public static class Extensions
{
    public static void IterateOver(this IEnumerable<User> users, UserPredicate predicate, Action<User> action)
    {
        foreach (var user in users)
        {
            if (predicate(user))
            {
                action(user);
            }
        }
    }
}
