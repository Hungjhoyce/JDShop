using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface ICartRepository
    {
        Task<List<Cart>>  GetAllAsync();
        Task<Cart?> GetByIdAsync(Guid id);
        Task<Cart> CreateAsync(Cart cartModel);
    }
}