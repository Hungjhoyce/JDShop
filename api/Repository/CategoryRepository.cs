using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Category;
using api.Interfaces;
using api.Models;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _context;
        public CategoryRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<bool> CategoryExists(int id)
        {
            return _context.Categorys.AnyAsync(s => s.Id == id);
        }

        public async Task<Category> CreateAsync(Category categoryModel)
        {
            await _context.Categorys.AddAsync(categoryModel);
            await _context.SaveChangesAsync();

            return categoryModel;
        }

        public async Task<Category?> DeleteAsync(int id)
        {
            var categoryModel = await _context.Categorys.FirstOrDefaultAsync(x => x.Id == id);

            if(categoryModel == null)
            {
                return null;
            }

            _context.Categorys.Remove(categoryModel);
            await _context.SaveChangesAsync();

            return categoryModel;
        }

        public Task<List<Category>> GetAllAsync()
        {
            return _context.Categorys.Include(c => c.Products).ThenInclude(c => c.ProductVariants).ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categorys.Include(c => c.Products).ThenInclude(c => c.ProductVariants).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Category?> UpdateAsync(int id, UpdateCategoryRequestDto categoryDto)
        {
            var existingCategory = await _context.Categorys.FirstOrDefaultAsync(x => x.Id == id);

            if(existingCategory == null)
            {
                return null;
            }

            existingCategory.Name = categoryDto.Name;
            existingCategory.Description = categoryDto.Description;

            await _context.SaveChangesAsync();

            return existingCategory;
        }
    }
}