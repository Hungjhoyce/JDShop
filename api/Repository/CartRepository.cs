using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDBContext _context;

        public CartRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Cart> CreateAsync(Cart cartModel)
        {
            await _context.Carts.AddAsync(cartModel);
            await _context.SaveChangesAsync();

            return cartModel;
        }

        public async Task<List<Cart>> GetAllAsync()
        {
            return await _context.Carts.ToListAsync();
        }

        public async Task<Cart?> GetByIdAsync(Guid id)
        {
            return await _context.Carts.FindAsync(id);
        }
    }
}