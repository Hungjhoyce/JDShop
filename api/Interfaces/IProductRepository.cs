using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(Guid id);
        Task<Product> CreateAsync(Product productModel);
        Task<Product?> UpdateAsync(Guid id, Product productModel);
        Task<Product?> DeleteAsync(Guid id);
        Task<bool> ProductExists(Guid id);
    }
}