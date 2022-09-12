
using FA22.P04.Web.Features.Users;
using FA22.P04.Web.Features.UserRoles;
using Microsoft.AspNetCore.Identity;
namespace FA22.P04.Web.Features.Roles;

public class Role : IdentityRole<int>
{
    public string RoleName { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }

}
