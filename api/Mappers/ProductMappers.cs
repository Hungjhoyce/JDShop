using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Product;
using api.Models;

namespace api.Mappers
{
    public static class ProductMappers
    {
        public static ProductDto ToProductDto(this Product productModel)
        {
            return new ProductDto
            {
                Id = productModel.Id,
                Name = productModel.Name,
                Description = productModel.Description,
                Price = productModel.Price,
                Stock = productModel.Stock,
                CategoryId = productModel.CategoryId,
                Image = productModel.Image,
                ProductVariants = productModel.ProductVariants.Select(c => c.ToProductVariantDto()).ToList()
            };
        }

        public static Product ToProductFromCreate(this CreateProductDto productDto, int categoryId)
        {
            return new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                Stock = productDto.Stock,
                CategoryId = categoryId,
                Image = productDto.Image
            };
        }

        public static Product ToProductFromUpdate(this UpdateProductRequestDto productDto)
        {
            return new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                Stock = productDto.Stock,
                Image = productDto.Image
            };
        }
    }
}