using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using UserManagementWebApp.DTO;
using UserManagementWebApp.Interfaces;
using UserManagementWebApp.Models;


//API controller to controll the API requests
namespace UserManagementWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersApiController : ControllerBase
    {
        private readonly IUsersRepository _userRepository;

        public UsersApiController(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //HTTP/GET Users, get all users
        //GET/Users
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userRepository.GetUsers();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(users);
        }

        //HTTP/GET User, get user by id
        //GET/Users/id
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser(int userId)
        {
            ////First check if userId is a number (checked at input level)
            //if(userId < 0)
            //{
            //    return BadRequest(ModelState);
            //}
            //Check if there is an existing user, if not return not found
            bool exists = await _userRepository.UserExist(userId);
            if (!exists)
            {
                return NotFound(ModelState);
            }

            var user = await _userRepository.GetUser(userId);

            return Ok(user);
        }

        //HTTP/POST Create, creates a user from UserDto (client has to input just the Name, Emal, BirthDate; Id and RegistrationDate is assigned automatically
        //POST/Users
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDto userCreate)
        {
            //Create User from the data that was given by the user
            User user = new User()
            {
                Name = userCreate.Name,
                Email = userCreate.Email,
                BirthDate = userCreate.BirthDate,
            };

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please fill out all paramaters!");
                return BadRequest(ModelState);
            }

            //If user already exists throw error
            if (await _userRepository.UserExist(user))
            {
                ModelState.AddModelError("", "User with this email already exists");
                return Conflict(ModelState);
            }

            //Try to create it, if anything went wrong throw error
            if (!await _userRepository.CreateUser(user))
            {
                ModelState.AddModelError("", "Could not save to database");
                return BadRequest(ModelState);
            }

            return Ok(user);
        }

        //HTTP/PUT Update, Updates an existing user
        //PUT/Users/id
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, [FromBody] User userNew)
        {
            //Check if data is usable
            if(!await _userRepository.UserExist(userId)) { 
                return NotFound(); 
            }

            if (userNew == null)
            {
                return BadRequest(ModelState);
            }

            if (userId != userNew.Id)
            {
                ModelState.AddModelError("", "Wrong ID");
                return BadRequest(ModelState);
            }


            //If anything went wrong during saving, throw error
            if (!await _userRepository.UpdateUser(userNew))
            {
                ModelState.AddModelError("", "Something went wrong during saving");
                return BadRequest(ModelState);
            }

            return NoContent();
        }

        //HTTP/DELETE Delete, deletes an existing user
        //DELETE/Users/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            //Check if user exists
            if (!await _userRepository.UserExist(id))
            {
                return NotFound();
            }

            //Check if saving was successful
            if (!await _userRepository.DeleteUser(id))
            {
                ModelState.AddModelError("", "Something went wrong during saving");
                return BadRequest(ModelState);
            }

            return NoContent();
        }
    }
}   
