using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;
        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<User> CreateAsync(User userModel)
        {
            await _context.AddAsync(userModel);
            await _context.SaveChangesAsync();

            return userModel;
        }

        public async Task<User?> DeleteAsync(Guid id)
        {
            var userModel = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if(userModel == null)
            {
                return null;
            }

            _context.Users.Remove(userModel);
            await _context.SaveChangesAsync();

            return userModel;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> UpdateAsync(Guid id, User userModel)
        {
            var existingUser = await _context.Users.FindAsync(id);

            if (existingUser == null)
            {
                return null;
            }

            existingUser.Username = userModel.Username;
            existingUser.Password = userModel.Password;
            existingUser.Email = userModel.Email;
            existingUser.FirstName = userModel.FirstName;
            existingUser.LastName = userModel.LastName;
            existingUser.Address = userModel.Address;
            existingUser.Phone = userModel.Phone;
            existingUser.Role = userModel.Role;

            await _context.SaveChangesAsync();

            return existingUser;
        }
    }
}