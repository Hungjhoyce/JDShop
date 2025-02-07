using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.ProductVariant;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ProductVariantRepository : IProductVariantRepository
    {
        private readonly ApplicationDBContext _context;
        public ProductVariantRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<ProductVariant> CreateAsync(ProductVariant productVariantModel)
        {
            await _context.ProductVariants.AddAsync(productVariantModel);
            await _context.SaveChangesAsync();

            return productVariantModel;
        }

        public async Task<ProductVariant?> DeleteAsync(int id)
        {
            var productVariantModel = await _context.ProductVariants.FirstOrDefaultAsync(x => x.Id == id);

            if(productVariantModel == null)
            {
                return null;
            }

            _context.ProductVariants.Remove(productVariantModel);
            await _context.SaveChangesAsync();

            return productVariantModel;
        }

        public async Task<List<ProductVariant>> GetAllAsync()
        {
            return await _context.ProductVariants.ToListAsync();
        }

        public async Task<ProductVariant?> GetByIdAsync(int id)
        {
            return await _context.ProductVariants.FindAsync(id);
        }

        public async Task<ProductVariant?> UpdateAsync(int id, ProductVariant productVariantModel)
        {
            var existingProductVariant = await _context.ProductVariants.FindAsync(id);

            if(existingProductVariant == null)
            {
                return null;
            }

            existingProductVariant.Size = productVariantModel.Size;
            existingProductVariant.Color = productVariantModel.Color;
            existingProductVariant.Stock = productVariantModel.Stock;
            existingProductVariant.Price = productVariantModel.Price;

            await _context.SaveChangesAsync();

            return existingProductVariant;

        }
    }
}