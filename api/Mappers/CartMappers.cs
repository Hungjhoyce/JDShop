using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Cart;
using api.Models;

namespace api.Mappers
{
    public static class CartMappers
    {
        public static CartDto ToCartDto(this Cart cartModel)
        {
            return new CartDto
            {
                Id = cartModel.Id,
                Quantity = cartModel.Quantity,
                ProductId = cartModel.ProductId,
                ProductVariantId = cartModel.ProductVariantId,
                UserID = cartModel.UserID
            };
        }
        

        public static Cart ToCartFromCreate(this CreateCartRequestDto cartDto)
        {
            return new Cart
            {
                Quantity = cartDto.Quantity,
                ProductId = cartDto.ProductId,
                ProductVariantId = cartDto.ProductVariantId,
                UserID = cartDto.UserID
            };
        }
    }
}