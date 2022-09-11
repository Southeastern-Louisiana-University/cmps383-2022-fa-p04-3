using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FA22.P04.Web.Data;
using FA22.P04.Web.Features;
using FA22.P04.Web.Features.Users;
namespace FA22.P04.Web.Controllers;

[Route("/api/user")]
[ApiController]

public class UsersController : ControllerBase
{
    private readonly DbSet<User> users;
    private readonly DataContext dataContext;
    public UsersController(DataContext dataContext)
    {
        this.dataContext = dataContext;
        users = dataContext.Set<User>();

    }
    [HttpGet]
    [Route("/users/{id}")]
    public ActionResult<List<UserDto>> GetProductUsers(int id)
    {
        if (!users.Any(x => x.Id == id))
        {
            return NotFound();
        }



        return Ok(users);
    }
}