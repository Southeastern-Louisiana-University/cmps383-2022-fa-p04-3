
using FA22.P04.Web.Features.Users;
namespace FA22.P04.Web.Features.UserRoles;

public class UserRole
{
    public int Id { get; set; }
    public User user { get; set; }
    public UserRole Role { get; set; }

}
