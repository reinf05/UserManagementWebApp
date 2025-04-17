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
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser(int userId)
        {
            //First check if there is an existing user, if not return not found
            bool exists = await _userRepository.UserExist(userId);
            if (!exists)
            {
                return NotFound(ModelState);
            }

            var user = await _userRepository.GetUser(userId);

            return Ok(user);
        }

        //HTTP/POST Create, creates a user from UserDto (client has to input just the Name, Emal, BirthDate; Id and RegistrationDate is assigned automatically
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

            //If user already exists throw error
            if (await _userRepository.UserExist(user))
            {
                ModelState.AddModelError("", "User with this email already exists");
                return BadRequest(ModelState);
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
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, [FromBody] UserDto userDto)
        {
            //Check if data is usable
            if(!await _userRepository.UserExist(userId)) { 
                return NotFound(); 
            }

            if (userDto == null)
            {
                return BadRequest(ModelState);
            }

            if (userId != userDto.Id)
            {
                ModelState.AddModelError("", "Wrong ID");
                return BadRequest(ModelState);
            }

            //Create the new user that will "replace" the old one
            User updatedUser = new User()
            {
                Id = userId,
                Name = userDto.Name,
                Email = userDto.Email,
                BirthDate = userDto.BirthDate
            };

            //If anything went wrong during saving, throw error
            if (!await _userRepository.UpdateUser(updatedUser))
            {
                ModelState.AddModelError("", "Something went wrong during saving");
                return BadRequest(ModelState);
            }

            return NoContent();
        }

        //HTTP/DELETE Delete, deletes an existing user
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
