using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FA22.P04.Web.Data;
using FA22.P04.Web.Features;
using FA22.P04.Web.Features.Users;
using FA22.P04.Web.Features.CreateUser;
using Microsoft.AspNetCore.Authorization;
namespace FA22.P04.Web.Controllers;


[Route("/api/user")]
[ApiController]

public class UsersController : Controller
{
    private readonly DbSet<User> users;
    private readonly DataContext dataContext;
    public UsersController(DataContext dataContext)
    {
        this.dataContext = dataContext;
        users = dataContext.Set<User>();

    }
    [HttpGet]
    [Route("/users/")]
    public ActionResult<List<UserDto>> GetUsers()
    {




        return Ok(users);
    }

    /*[HttpPost]
    [Route("/api/users")]
    [Authorize(Policy = "RequireAdministratorRole")]

    public ActionResult CreateUser(CreateUserDto user)
    {


        //          Only admins can do this
        // ■ Only allow roles that exist to be sent
        // ■ Must provide at least one role
        // ■ Only allow unique usernames
        // return Ok(UserDto createdUser)
        return Ok();
    }*/

    //Create
    [HttpPost]
    [Route("/api/users")]
    //[Authorize(Policy = "RequireAdministratorRole")]
    public async Task<IActionResult> OnPost(CreateUserDto input, string? returnUrl = "S")
    {
        returnUrl = returnUrl ?? Url.Content("~/");

        var existant = GetUserDtos(users.Where(x => x.UserName == input.UserName)).FirstOrDefault();
        if (existant == null)
        {
            if (PwdIsValid(input.Password))
            {
                var user = new User
                {
                    UserName = input.UserName,
                    Password = input.Password,
                    Role = "User"
                };
                users.Add(user);

                dataContext.SaveChanges();

                return Created("UserDb", "Created " + input.UserName + "... :)");
            }
            return BadRequest("Password is invalid");
        }
        return BadRequest("User Already Exists");
    }

    [HttpDelete]
    [Route("/api/users")]
    //[Authorize(Policy = "RequireAdministratorRole")]
    public async Task<IActionResult> OnDelete(string user)
    {
        var existant = GetUserDtos(users.Where(x => x.UserName == user)).FirstOrDefault();
        if (existant != null)
        {
            users.Remove((users.Where(x => x.UserName == user)).FirstOrDefault());
            dataContext.SaveChanges();
            return Ok();
        }

        return BadRequest("Don't exist bro");
    }
    private bool UserIsValid(CreateUserDto check)
    {
        var pwd = check.Password;

        var existant = GetUserDtos(users.Where(x => x.UserName == check.UserName)).FirstOrDefault();

        if (existant == null && PwdIsValid(pwd))
        {
            return true;
        }

        return false;
    }
    private bool PwdIsValid(string Pswd)
    {
        int time = Pswd.Length;
        char[] pwd = Pswd.ToCharArray();
        bool upper = false;
        bool lower = false;
        bool number = false;
        bool special = false;

        foreach (char i in pwd)
        {
            if (Char.IsUpper(i))
            {
                upper = true;
            }
            if (Char.IsLower(i))
            {
                lower = true;
            }
            if (Char.IsNumber(i))
            {
                number = true;
            }
            if (Char.IsSymbol(i) || Char.IsPunctuation(i))
            {
                special = true;
            }
        }

        if (time > 5 && upper && lower && number && special)
        {
            return true;
        }

        return false;
    }
    private static IQueryable<UserDto> GetUserDtos(IQueryable<User> users)
    {
        return users
            .Select(x => new UserDto
            {
                Id = x.Id,
                UserName = x.UserName,
                UserRoles = x.UserRoles
            });
    }
}