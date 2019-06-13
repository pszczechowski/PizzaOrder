using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using PizzaPortal.Contract.PizzaTemplatesDto;
using PizzaPortal.Core.Services;

namespace PizzaPortal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UserController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet("GetUser/{Id}")]
        public async Task<IActionResult> GetUserById(long id)
        {
            try
            {
                var user = await _usersService.GetById(id);
                return Ok(user);

            }
            catch (NullReferenceException )
            {
                return NotFound($"Can't found user with id = {id}");
            }
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _usersService.GetAll();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UsersDto user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            await _usersService.Add(user);
            return Created("Create new User", user);
        }
        
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UsersDto user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            await _usersService.Update(user);
            return Ok($"Update user with id ={user.Id}");
        }
        

        }

    }
