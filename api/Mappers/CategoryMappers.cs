using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Category;
using api.Models;

namespace api.Mappers
{
    public static class CategoryMappers
    {
        public static CategoryDto ToCategoryDto(this Category categoryModel)
        {
            return new CategoryDto
            {
                Id = categoryModel.Id,
                Name = categoryModel.Name,
                Description = categoryModel.Description,
                Products = categoryModel.Products.Select(c => c.ToProductDto()).ToList()
            };
        }

        public static Category ToCategoryFromCrateDTO(this CreateCategoryRequestDto categoryDto)
        {
            return new Category
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description
            };
        }
    }
}