using IdType = System.Guid;

namespace ClassDiagram.Entities.Users;

public class Barber : User
{
    public IdType BarbershopId { get; set; }

    public Barbershop Barbershop { get; set; }

    public virtual IList<Booking> Calendar { get; set; }
}
