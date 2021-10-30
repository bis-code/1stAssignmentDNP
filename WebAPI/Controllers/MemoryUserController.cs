using System;
using System.Threading.Tasks;
using FirstAssignmentDNP.Authentication;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MemoryUserController : ControllerBase
    {
        private readonly IUserService _userService;

        public MemoryUserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet]
        public async Task<ActionResult<User>> ValidateUser([FromQuery] string username, [FromQuery] string password)
        {
            Console.WriteLine("Here");
            try
            {
                var user = await _userService.ValidateUser(username, password);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}