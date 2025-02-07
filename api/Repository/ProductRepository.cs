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
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _context;
        public ProductRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(Product productModel)
        {
            await _context.Products.AddAsync(productModel);
            await _context.SaveChangesAsync();

            return productModel;
        }

        public async Task<Product?> DeleteAsync(int id)
        {
            var productModel = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if(productModel == null)
            {
                return null;
            }

            _context.Products.Remove(productModel);
            await _context.SaveChangesAsync();

            return productModel;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.Include(c => c.ProductVariants).ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.Include(c => c.ProductVariants).FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task<bool> ProductExists(int id)
        {
            return _context.Products.AnyAsync(s => s.Id == id);
        }

        public async Task<Product?> UpdateAsync(int id, Product productModel)
        {
            var existingProduct = await _context.Products.FindAsync(id);

            if(existingProduct == null)
            {
                return null;
            }

            existingProduct.Name = productModel.Name;
            existingProduct.Description = productModel.Description;
            existingProduct.Price = productModel.Price;
            existingProduct.Stock = productModel.Stock;
            existingProduct.Image = productModel.Image;

            await _context.SaveChangesAsync();

            return existingProduct;
        }
    }
}