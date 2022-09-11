
using FA22.P04.Web.Features.Users;
using FA22.P04.Web.Features.UserRoles;
namespace FA22.P04.Web.Features.Roles;

public class Role
{
    // public ICollection<UserRole> Users { get; set; }
    public int Id { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }
}
