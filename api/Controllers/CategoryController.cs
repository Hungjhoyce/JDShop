using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Category;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ApplicationDBContext context, ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
            _context = context;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var categorys = await _categoryRepo.GetAllAsync();
            var categoryDto = categorys.Select(s => s.ToCategoryDto());

            return Ok(categorys);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var category = await _categoryRepo.GetByIdAsync(id);

            if(category == null)
            {
                return NotFound();
            }

            return Ok(category.ToCategoryDto());
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryRequestDto categoryDto)
        {
            var categoryModel = categoryDto.ToCategoryFromCrateDTO();
            await _categoryRepo.CreateAsync(categoryModel);

            return CreatedAtAction(nameof(GetById), new {id = categoryModel.Id}, categoryModel.ToCategoryDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCategoryRequestDto updateDto)
        {
            var categoryModel = await _categoryRepo.UpdateAsync(id, updateDto);

            if(categoryModel == null)
            {
                return NotFound();
            }

            categoryModel.Name = updateDto.Name;
            categoryModel.Description = updateDto.Description;

            await _context.SaveChangesAsync();

            return Ok(categoryModel.ToCategoryDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var categoryModel = await _categoryRepo.DeleteAsync(id);

            if(categoryModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}