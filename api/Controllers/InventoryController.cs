using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Inventory;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/inventory")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryRepository _inventoryRepo;
        private readonly IProductRepository _productRepo;
        public InventoryController(IInventoryRepository inventoryRepo, IProductRepository productRepo)
        {
            _inventoryRepo = inventoryRepo;
            _productRepo = productRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var inventorys = await _inventoryRepo.GetAllAsync();
            var InventoryDto = inventorys.Select(s => s.ToInventoryDto());

            return Ok(InventoryDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var inventory = await _inventoryRepo.GetByIdAsync(id);

            if(inventory == null)
            {
                return NotFound();
            }

            return Ok(inventory.ToInventoryDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateInventoryDto inventoryDto)
        {
            var inventoryModel = inventoryDto.ToInventoryFromCreate();
            await _inventoryRepo.CreateAsync(inventoryModel);

            return CreatedAtAction(nameof(GetById), new {id = inventoryModel.Id}, inventoryModel.ToInventoryDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateInventoryRequestDto updateDto)
        {
            var inventory = await _inventoryRepo.UpdateAsyc(id, updateDto.ToInventoryFromUpdate());

            if(inventory == null)
            {
                return NotFound("Khong tim thay");
            }

            return Ok(inventory.ToInventoryDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var inventoryModel = await _inventoryRepo.DeleteAsync(id);

            if(inventoryModel == null)
            {
                return NotFound("Khong tim thay");
            }

            return Ok(inventoryModel);
        }
    }
}