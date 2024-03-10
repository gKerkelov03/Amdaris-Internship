namespace ClassDiagram.Entities.Users;

public class Customer : User
{
    public virtual IList<Subscription> OngoingSubscriptions { get; set; }

    public virtual IList<Booking> ActiveBookings { get; set; }
}
