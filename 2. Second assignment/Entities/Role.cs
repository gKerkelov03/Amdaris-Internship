using ClassDiagram.Entities.Base;
using IdType = System.Guid;

namespace ClassDiagram.Entities;

public class Role : BaseEntity<IdType>
{
    public string Name { get; set; }
}