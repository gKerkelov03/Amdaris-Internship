using ClassDiagram.Entities.Base;
using IdType = System.Guid;

namespace ClassDiagram.Entities;

public class TimeSlot : BaseEntity<IdType>
{
    public TimeOnly From { get; set; }

    public TimeOnly To { get; set; }
}