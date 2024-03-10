using ClassDiagram.Entities.Base;
using ClassDiagram.Entities.Users;
using IdType = System.Guid;

namespace ClassDiagram.Entities;

public class Booking : BaseEntity<IdType>
{
    public IdType TimeSlotId { get; set; }

    public virtual TimeSlot TimeSlot { get; set; }

    public IdType CustomerId { get; set; }

    public virtual Customer Customer { get; set; }

    public IdType BarbershopId { get; set; }

    public virtual Barbershop Barbershop { get; set; }

    public IdType BarberId { get; set; }

    public virtual Barber Barber { get; set; }
}