using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FA22.P04.Web.Data;
using FA22.P04.Web.Features;
using FA22.P04.Web.Features.Users;
using FA22.P04.Web.Features.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using FA22.P04.Web.Features.CreateUser;

namespace FA22.P04.Web.Controllers;

[Route("/api/user")]
[ApiController]

public class AuthenticationController : ControllerBase
{
    private readonly DbSet<User> users;
    private readonly DataContext dataContext;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly ILogger<AuthenticationController> _logger;
    public AuthenticationController(DataContext dataContext)
    {
        this.dataContext = dataContext;
        users = dataContext.Set<User>();

    }


    //login
    [HttpPost]
    [Route("/api/Identity/Account/Login")]
    public async Task<IActionResult> OnPostAsync(LoginDto Input, string returnUrl = null)
    {
        returnUrl = returnUrl ?? Url.Content("~/");

        if (ModelState.IsValid)
        {
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, 
            // set lockoutOnFailure: true
            var result = await _signInManager.PasswordSignInAsync(Input.UserName,
                               Input.Password, isPersistent: true, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                _logger.LogInformation("User logged in.");
                // get user by id

                var user = GetUserDtos(users.Where(x => x.UserName == Input.UserName)).FirstOrDefault();
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
        }
        return BadRequest();
    }

    [HttpPost]
    [Route("/api/Identity/Account/Create")]
    public async Task<IActionResult> OnPost(CreateUserDto input, string returnUrl = null)
    {
        returnUrl = returnUrl ?? Url.Content("~/");

        var existant = GetUserDtos(users.Where(x => x.UserName == input.UserName)).FirstOrDefault();
        if (existant == null)
        {
            var user = new User
            {
                UserName = input.UserName,
                Password = input.Password,
                Role = "User"

            };
            users.Add(user);

            dataContext.SaveChanges();

            return Created("Created ", input.UserName);
        }
        return BadRequest("User Already Exists");
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
