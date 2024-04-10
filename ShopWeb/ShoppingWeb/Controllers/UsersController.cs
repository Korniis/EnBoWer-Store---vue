using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingWeb.Data;
using ShoppingWeb.Services.Interfaces;
using ShoppingWeb.ViewModel;

namespace ShoppingWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService,MyDbContext ctx)
        {
            _userService = userService;

        }


        [HttpPost("auth")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
             var response = _userService.Authenticate(model);
             
            if(response == null)
            {
                return BadRequest(new { message = " Account or password not corret" });


            }
            return Ok(response); 
        }
    }
    
}
