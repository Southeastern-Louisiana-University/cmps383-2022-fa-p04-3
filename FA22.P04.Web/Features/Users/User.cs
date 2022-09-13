
using FA22.P04.Web.Features.Roles;
using Microsoft.AspNetCore.Identity;
namespace FA22.P04.Web.Features.Users;

public class User : IdentityUser<int>
{
    public ICollection<UserRole> UserRoles { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }

    public string Role { get; set; }
}
