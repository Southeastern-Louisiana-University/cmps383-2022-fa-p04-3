namespace FA22.P04.Web.Features.CreateUser;

public class CreateUserDto
{
    public string UserName { get; set; }
    public string[] Roles { get; set; }
    public string Password { get; set; }
}
