using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Category;
using api.Models;

namespace api.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(Guid id);
        Task<Category> CreateAsync(Category categoryModel);
        Task<Category?> UpdateAsync(Guid id, UpdateCategoryRequestDto categoryDto);
        Task<Category?> DeleteAsync(Guid id);
        Task<bool> CategoryExists(Guid id);
    }
}