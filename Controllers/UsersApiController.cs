﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using UserManagementWebApp.DTO;
using UserManagementWebApp.Interfaces;
using UserManagementWebApp.Models;

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

        [HttpGet]
        public async Task<IActionResult> GetUser(int id)
        {
            bool exists = await _userRepository.UserExist(id);
            if (!exists)
            {
                return NotFound(ModelState);
            }

            var user = await _userRepository.GetUser(id);

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDto userCreate)
        {
            var user = new User()
            {
                Name = userCreate.Name,
                Email = userCreate.Email,
                BirthDate = userCreate.BirthDate,
            };

            if (await _userRepository.UserExist(user))
            {
                ModelState.AddModelError("", "User with this email already exists");
                return BadRequest(ModelState);
            }

            if(!await _userRepository.CreateUser(user))
            {
                ModelState.AddModelError("", "Could not save to database");
                return BadRequest(ModelState);
            }
            
            return Ok(user);
        }


        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, [FromBody] UserDto userDto)
        {
            if(userDto == null)
            {
                return BadRequest(ModelState);
            }

            if(userId != userDto.Id)
            {
                ModelState.AddModelError("", "Wrong ID");
                return BadRequest(ModelState);
            }

            User updatedUser = new User()
            {
                Id = userId,
                Name = userDto.Name,
                Email = userDto.Email,
                BirthDate = userDto.BirthDate
            };

            if(! await _userRepository.UpdateUser(updatedUser))
            {
                ModelState.AddModelError("", "Something went wrong during saving");
                return BadRequest(ModelState);
            }

            return NoContent();
        }
    }
}   
