
using System.ComponentModel.DataAnnotations;

namespace ClassDiagram.Entities.Base;

public abstract class BaseEntity<IdType>
{
    [Key]
    IdType ID { get; set; }
}
