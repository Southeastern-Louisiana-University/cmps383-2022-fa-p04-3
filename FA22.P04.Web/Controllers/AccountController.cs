using FA22.P04.Web.Data;
using FA22.P04.Web.Features;
using FA22.P04.Web.Features.CreateUser;
using FA22.P04.Web.Features.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FA22.P04.Web.Controllers
{
    public class AccountController : Controller
    {
       public AccountController (UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {

        }

        [HttpGet]
        [Route ("/api/getUsers")]

        public IActionResult Register()
        {
            return View();
        }


       /* [HttpGet]
        [Route("/users/")]
        public ActionResult<List<UserDto>> GetUsers()
        {




            return Ok(users);
        }
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
        }*/
    }
}
