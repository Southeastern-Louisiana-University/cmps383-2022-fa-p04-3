
using FA22.P04.Web.Features.UserRoles;
namespace FA22.P04.Web.Features.Users;

public class User
{
    public int Id { get; set; }
    // public ICollection<UserRole> Roles { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }
    public string PasswordString { get; set; }
    public string UserNameString { get; set; }
}
