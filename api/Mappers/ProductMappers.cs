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
                Stock = productModel.StockQuantity,
                CategoryId = productModel.CategoryId,
                Image = productModel.ImageUrl,
                ProductVariants = productModel.ProductVariants.Select(c => c.ToProductVariantDto()).ToList(),
                reviews = productModel.Reviews.Select(c => c.ToReviewDto()).ToList()
            };
        }

        public static Product ToProductFromCreate(this CreateProductDto productDto)
        {
            return new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                StockQuantity = productDto.Stock,
                CategoryId = productDto.CategoryId,
                ImageUrl = productDto.Image
            };
        }

        public static Product ToProductFromUpdate(this UpdateProductRequestDto productDto)
        {
            return new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                StockQuantity = productDto.Stock,
                ImageUrl = productDto.Image
            };
        }
    }
}