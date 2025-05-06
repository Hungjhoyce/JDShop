using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.User;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepo.GetAllAsync();

            var userDto = users.Select(s => s.ToUserDto());

            return Ok(userDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var user = await _userRepo.GetByIdAsync(id);

            if(user == null)
            {
                return NotFound("Khong tim thay user");
            }

            return Ok(user.ToUserDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto userDto)
        {
            var userModel = userDto.ToUserFromCreate();
            await _userRepo.CreateAsync(userModel);

            return CreatedAtAction(nameof(GetById), new {id = userModel.Id}, userModel.ToUserDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateUserDto userDto)
        {
            var user = await _userRepo.UpdateAsync(id, userDto.ToUserFromUpdate());

            if(user == null)
            {
                return NotFound("khong tim thay user");
            }

            return Ok(user.ToUserDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var userModel = await _userRepo.DeleteAsync(id);

            if(userModel == null)
            {
                return NotFound("User khong ton tai");
            }

            return Ok(userModel);
        }
    }
}