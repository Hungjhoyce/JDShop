using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.ProductVariant;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/productvariant")]
    [ApiController]
    public class ProductVariantController : ControllerBase
    {
        private readonly IProductVariantRepository _productVariantRepo; 
        private readonly IProductRepository _productRepo;
        public ProductVariantController(IProductVariantRepository productVariantRepo, IProductRepository productRepo)
        {
            _productVariantRepo = productVariantRepo;
            _productRepo = productRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productVariants = await _productVariantRepo.GetAllAsync();

            var ProductVariantDto = productVariants.Select(s => s.ToProductVariantDto());

            return Ok(ProductVariantDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var productVariant = await _productVariantRepo.GetByIdAsync(id);

            if(productVariant == null)
            {
                return NotFound("Khong tim thay loai san pham");
            }

            return Ok(productVariant.ToProductVariantDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductVariantDto productVariantDto)
        {

            var productVariantModel = productVariantDto.ToProductVariantFromCreate();
            await _productVariantRepo.CreateAsync(productVariantModel);

            return CreatedAtAction(nameof(GetById), new {id = productVariantModel.Id}, productVariantModel.ToProductVariantDto());

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateProductVariantDto updateDto)
        {
            var productVariant = await _productVariantRepo.UpdateAsync(id, updateDto.ToProductVariantFromUpdate());

            if(productVariant == null)
            {
                return NotFound("Khong tim thay loai san pham");
            }

            return Ok(productVariant.ToProductVariantDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var productVariantModel = await _productVariantRepo.DeleteAsync(id);

            if(productVariantModel == null)
            {
                return NotFound("Loai san pham khong ton tai");
            }

            return Ok(productVariantModel);
        }
    }
}