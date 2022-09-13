
using FA22.P04.Web.Features.Users;
using Microsoft.AspNetCore.Identity;

namespace FA22.P04.Web.Features.Roles;

public class Role : IdentityRole<int>
{
    public string RoleName { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }

}
