
using FA22.P04.Web.Features.Users;
using FA22.P04.Web.Features.Roles;
namespace FA22.P04.Web.Features.UserRoles;


public class UserRole
{
    // public int Id { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }
    public User User { get; set; }
    public Role Role { get; set; }


}
