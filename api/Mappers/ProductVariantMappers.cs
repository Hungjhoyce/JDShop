using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.ProductVariant;
using api.Models;

namespace api.Mappers
{
    public static class ProductVariantMappers
    {
        public static ProductVariantDto ToProductVariantDto(this ProductVariant productVariantModel)
        {
            return new ProductVariantDto
            {
                Id = productVariantModel.Id,
                Size = productVariantModel.Size,
                Color = productVariantModel.Color,
                Stock = productVariantModel.Stock,
                Price = productVariantModel.Price,
                ProductId = productVariantModel.ProductId
            };
        }

        public static ProductVariant ToProductVariantFromCreate(this CreateProductVariantDto productVariantDto, int productId)
        {
            return new ProductVariant
            {
                Size = productVariantDto.Size,
                Color = productVariantDto.Color,
                Stock = productVariantDto.Stock,
                Price = productVariantDto.Price,
                ProductId = productId
            };
        }

        public static ProductVariant ToProductVariantFromUpdate(this UpdateProductVariantDto productVariantDto)
        {
            return new ProductVariant
            {
                Size = productVariantDto.Size,
                Color = productVariantDto.Color,
                Stock = productVariantDto.Stock,
                Price = productVariantDto.Price,
            };
        }
    }
}