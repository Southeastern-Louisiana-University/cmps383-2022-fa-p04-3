
using FA22.P04.Web.Features.Users;
using Microsoft.AspNetCore.Identity;

namespace FA22.P04.Web.Features.Roles;


public class UserRole : IdentityUserRole<int>
{
    public int UserId { get; set; }
    public int RoleId { get; set; }
    public User User { get; set; }
    public Role Role { get; set; }


}
