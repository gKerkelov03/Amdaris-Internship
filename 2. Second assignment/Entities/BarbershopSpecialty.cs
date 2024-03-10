using ClassDiagram.Entities.Base;
using IdType = System.Guid;

namespace ClassDiagram.Entities;

public class BarbershopSpecialty : BaseEntity<IdType>
{
    public string Description { get; set; }
}