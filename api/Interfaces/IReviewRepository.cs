using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IReviewRepository
    {
        Task<List<Review>> GetAllAsync();
        Task<Review?> GetByIdAsync(Guid id);
        Task<Review> CreateAsync(Review reviewModel);
        Task<Review?> UpdateAsync(Guid id, Review reviewModel);
        Task<Review?> DeleteAsync(Guid id);
    }
}