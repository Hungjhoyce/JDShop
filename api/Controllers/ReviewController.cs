using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Review;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/review")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepo;
        private readonly IProductRepository _productRepo;
        public ReviewController(IReviewRepository reviewRepo, IProductRepository productRepo)
        {
            _reviewRepo = reviewRepo;
            _productRepo = productRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reviews = await _reviewRepo.GetAllAsync();

            var ReviewDto = reviews.Select(s => s.ToReviewDto());

            return Ok(ReviewDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var review = await _reviewRepo.GetByIdAsync(id);

            if(review == null)
            {
                return NotFound("khong tim thay danh gia");
            }

            return Ok(review.ToReviewDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateReviewDto reviewDto)
        {

            var reviewModel = reviewDto.ToReviewFromCreate();
            await _reviewRepo.CreateAsync(reviewModel);

            return CreatedAtAction(nameof(GetById), new {id = reviewModel.Id}, reviewModel.ToReviewDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateReviewDto updateDto)
        {
            var review = await _reviewRepo.UpdateAsync(id, updateDto.ToReviewFromUpdate());

            if(review == null)
            {
                return NotFound("Khong tim thay danh gia");
            }

            return Ok(review.ToReviewDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var reviewModel = await _reviewRepo.DeleteAsync(id);

            if(reviewModel == null)
            {
                return NotFound("Danh gia khong ton tai");
            }

            return Ok(reviewModel);
        }

    }
}