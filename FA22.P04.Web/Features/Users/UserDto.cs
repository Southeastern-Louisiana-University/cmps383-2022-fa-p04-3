using FA22.P04.Web.Features.Roles;

namespace FA22.P04.Web.Features;

public class UserDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }

    public string Password { get; set; }
}
