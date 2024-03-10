using ClassDiagram.Entities.Base;
using IdType = System.Guid;

namespace ClassDiagram.Entities.Users;

public class User : BaseEntity<IdType>
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public string PasswordHash { get; set; }

    public IdType RoleId { get; set; }

    public Role Role { get; set; }
}
