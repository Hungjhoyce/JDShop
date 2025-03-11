using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Inventory;
using api.Models;

namespace api.Mappers
{
    public static class InventoryMappers
    {
        public static InventoryDto ToInventoryDto(this Inventory inventoryModel)
        {
            return new InventoryDto
            {
                Id = inventoryModel.Id,
                Stock = inventoryModel.Stock,
                ProductId = inventoryModel.ProductId
            };
        }

        public static Inventory ToInventoryFromCreate(this CreateInventoryDto inventoryDto)
        {
            return new Inventory
            {
                Stock = inventoryDto.Stock,
                ProductId = inventoryDto.ProductId

            };
        }

        public static Inventory ToInventoryFromUpdate(this UpdateInventoryRequestDto inventoryDto)
        {
            return new Inventory
            {
                Stock = inventoryDto.Stock,
                ProductId = inventoryDto.ProductId
            };
        }
    }
}