using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.ProductVariant;
using api.Models;

namespace api.Interfaces
{
    public interface IProductVariantRepository
    {
        Task<List<ProductVariant>> GetAllAsync();
        Task<ProductVariant?> GetByIdAsync(int id);
        Task<ProductVariant> CreateAsync(ProductVariant productVariantModel);
        Task<ProductVariant?> UpdateAsync(int id, ProductVariant productVariantModel);
        Task<ProductVariant?> DeleteAsync(int id);
    }
}