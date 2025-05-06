using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(Guid id);
        Task<User> CreateAsync(User userModel);
        Task<User?> UpdateAsync(Guid id, User userModel);
        Task<User?> DeleteAsync(Guid id);
    }
}