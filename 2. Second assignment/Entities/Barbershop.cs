using ClassDiagram.Entities.Base;
using ClassDiagram.Entities.Users;
using IdType = System.Guid;

namespace ClassDiagram.Entities;

public class Barbershop : BaseEntity<IdType>
{
    public string Name { get; set; }

    public string Description { get; set; }

    public string Location { get; set; }

    public bool SubscriptionsEnabled { get; set; }

    public bool BarbersCanMoveBookings { get; set; }

    public bool BarbersCanSetNonWorkingPeriods { get; set; }

    public IdType OwnerId { get; set; }

    public virtual Owner Owner { get; set; }

    public virtual IList<Barber> Barbers { get; set; }

    public virtual IList<BarbershopSpecialty> Specialties { get; set; }

}
