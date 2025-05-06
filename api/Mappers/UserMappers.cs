using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.User;
using api.Models;

namespace api.Mappers
{
    public static class UserMappers
    {
        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto
            {
                Id = userModel.Id,
                Username = userModel.Username,
                Password = userModel.Password,
                Email = userModel.Email,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Address = userModel.Address,
                Phone = userModel.Phone,
                Role = userModel.Role,
                CreatedAt = userModel.CreatedAt,
                UpdatedAt = userModel.UpdatedAt
            };
        }

        public static User ToUserFromCreate(this CreateUserDto userDto)
        {
            return new User
            {
                Username = userDto.Username,
                Password = userDto.Password,
                Email = userDto.Email,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Address = userDto.Address,
                Phone = userDto.Phone,
                Role = userDto.Role,
            };
        }

        public static User ToUserFromUpdate(this UpdateUserDto userDto)
        {
            return new User
            {
                Username = userDto.Username,
                Password = userDto.Password,
                Email = userDto.Email,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Address = userDto.Address,
                Phone = userDto.Phone,
                Role = userDto.Role,
            };
        }
    }
}