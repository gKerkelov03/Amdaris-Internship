using ClassDiagram.Entities.Base;
using IdType = System.Guid;

namespace ClassDiagram.Entities;

public class SpecialSlot : BaseEntity<IdType>
{
    public IdType TimeSlotId { get; set; }

    public virtual TimeSlot TimeSlot { get; set; }

    public IdType SubscriptionId { get; set; }

    public virtual Subscription Subscription { get; set; }
}