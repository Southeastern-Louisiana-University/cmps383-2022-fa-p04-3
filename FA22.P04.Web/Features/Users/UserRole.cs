
using FA22.P04.Web.Features.Users;
using FA22.P04.Web.Features.Roles;
using Microsoft.AspNetCore.Identity;
namespace FA22.P04.Web.Features.UserRoles;


public class UserRole : IdentityUserRole<int>
{
    public int UserId { get; set; }
    public int RoleId { get; set; }
    public User User { get; set; }
    public Role Role { get; set; }


}
