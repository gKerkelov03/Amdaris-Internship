using ClassDiagram.Entities.Base;
using ClassDiagram.Entities.Enums;
using ClassDiagram.Entities.Users;
using IdType = System.Guid;

namespace ClassDiagram.Entities;

public class Subscription : BaseEntity<IdType>
{
    public int TimePenalty { get; set; }

    public int BookingsInAdvance { get; set; }

    public SubscriptionTier Tier { get; set; }

    public SubscriptionTier Duration { get; set; }

    public GroomingArea GroomingArea { get; set; }

    public IdType BarbershopId { get; set; }

    public virtual Barbershop Barbershop { get; set; }

    public virtual IList<TimeSlot> SpecialSlots { get; set; }

    public virtual IList<Customer> ActiveCustomers { get; set; }
}
