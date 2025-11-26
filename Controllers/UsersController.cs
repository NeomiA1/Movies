using Microsoft.AspNetCore.Mvc;
using Movies.BL;
using Movies.DAL;

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        UserDAL dal = new UserDAL();

        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            bool ok = dal.RegisterUser(user);
            if (ok) return Ok();
            return BadRequest("Email already exists or insert failed");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            User logged = dal.LoginUser(user.Email, user.Password);
            if (logged == null) return Unauthorized();
            return Ok(logged);
        }
    }
}
