using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using FirstAssignmentDNP.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserDataController : ControllerBase
    {
        private readonly IUsersData _usersData;

        public UserDataController(IUsersData usersData)
        {
            _usersData = usersData;
        }

        [HttpGet]
        public async Task<ActionResult<IList<User>>> GetUsers([FromQuery] string? username)
        {
            try
            {
                IList<User> users = await _usersData.GetUsersAsync();
                if (username != null)
                {
                    users = users.Where(u => u.Username == username).ToList();
                }

                return Ok(users);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

            [HttpGet]
            [Route("{Id:int}")]
            public async Task<ActionResult<User>> GetUser([FromRoute] int id)
            {
                try
                {
                    await _usersData.GetUserAsync(id);
                    return Ok();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return StatusCode(500, e.Message);
                }
            }

            [HttpGet]
            [Route("{username}")]
            public async Task<ActionResult<User>> GetUser([FromRoute] string username)
            {
                try
                {
                    await _usersData.GetUserAsync(username);
                    return Ok();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return StatusCode(500, e.Message);
                }
            }

            [HttpPost]
            public async Task<ActionResult<User>> AddUser([FromBody] User user)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                try
                {
                    User added = await _usersData.AddUserAsync(user);
                    return Created($"/{added.Id}", added);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return StatusCode(500, e.Message);
                }
            }

            [HttpPost]
            [Route("{Id:int}")]
            public async Task<ActionResult<Family>> AddFamilyToUser([FromBody] Family family, [FromRoute] int Id)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                try
                {
                    Family added = await _usersData.AddFamilyToUserAsync(family, Id);
                    return Created($"/{added.Id}", added);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return StatusCode(500, e.Message);
                }
            }
            
            [HttpPost]
            [Route("{Id:int}")]
            public async Task<ActionResult<Family>> AddPersonToUser([FromBody] Person person, [FromRoute] int Id)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                try
                {
                    Person added = await _usersData.AddPersonToUserAsync(person, Id);
                    return Created($"/{added.Id}", added);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return StatusCode(500, e.Message);
                }
            }
            

    }
    }