namespace ClassDiagram.Entities.Users;

public class Owner : User
{
    public virtual IList<Barbershop> Barbershops { get; set; }
}
