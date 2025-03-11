using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly ApplicationDBContext _context;

        public InventoryRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Inventory> CreateAsync(Inventory inventoryModel)
        {
            await _context.Inventories.AddAsync(inventoryModel);
            await _context.SaveChangesAsync();

            return inventoryModel;

        }

        public async Task<Inventory?> DeleteAsync(Guid id)
        {
            var inventoryModel = await _context.Inventories.FirstOrDefaultAsync(x => x.Id == id);

            if(inventoryModel == null)
            {
                return null;
            }

            _context.Inventories.Remove(inventoryModel);
            await _context.SaveChangesAsync();

            return inventoryModel;
        }

        public async Task<List<Inventory>> GetAllAsync()
        {
            return await _context.Inventories.ToListAsync();
        }

        public async Task<Inventory?> GetByIdAsync(Guid id)
        {
            return await _context.Inventories.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Inventory?> UpdateAsyc(Guid id, Inventory inventoryModel)
        {
            var existingInventory = await _context.Inventories.FindAsync(id);

            if(existingInventory == null)
            {
                return null;
            }

            existingInventory.Stock = inventoryModel.Stock;

            await _context.SaveChangesAsync();

            return existingInventory;
        }
    }
}