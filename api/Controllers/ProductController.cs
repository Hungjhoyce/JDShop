using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Product;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        private readonly ICategoryRepository _categoryRepo;
        public ProductController(IProductRepository productRepo, ICategoryRepository categoryRepo)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productRepo.GetAllAsync();
            
            var ProductDto = products.Select(s => s.ToProductDto());

            return Ok(ProductDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var product = await _productRepo.GetByIdAsync(id);

            if(product == null)
            {
                return NotFound();
            }

            return Ok(product.ToProductDto());
        }

        [HttpPost("{categoryId}")]
        public async Task<IActionResult> Create([FromRoute] int categoryId, CreateProductDto productDto)
        {
            if(!await _categoryRepo.CategoryExists(categoryId))
            {
                return BadRequest("Category khong ton tai!");
            }

            var productModel = productDto.ToProductFromCreate(categoryId);
            await _productRepo.CreateAsync(productModel);

            return CreatedAtAction(nameof(GetById), new {id = productModel.Id}, productModel.ToProductDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProductRequestDto updateDto)
        {
            var product = await _productRepo.UpdateAsync(id, updateDto.ToProductFromUpdate());

            if(product == null)
            {
                return NotFound("Khong tim thay san pham(Product)");
            }

            return Ok(product.ToProductDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var productModel = await _productRepo.DeleteAsync(id);

            if(productModel == null)
            {
                return NotFound("San pham(Product) khong ton tai");
            }

            return Ok(productModel);
        }

    }
}