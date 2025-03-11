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
        Task<ProductVariant?> GetByIdAsync(Guid id);
        Task<ProductVariant> CreateAsync(ProductVariant productVariantModel);
        Task<ProductVariant?> UpdateAsync(Guid id, ProductVariant productVariantModel);
        Task<ProductVariant?> DeleteAsync(Guid id);
    }
}