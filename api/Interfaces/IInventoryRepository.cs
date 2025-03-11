using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IInventoryRepository
    {
        Task<List<Inventory>> GetAllAsync();
        Task<Inventory?> GetByIdAsync(Guid id);
        Task<Inventory> CreateAsync(Inventory inventoryModel);
        Task<Inventory?> UpdateAsyc(Guid id, Inventory inventoryModel);
        Task<Inventory?> DeleteAsync(Guid id);
        

    }
}