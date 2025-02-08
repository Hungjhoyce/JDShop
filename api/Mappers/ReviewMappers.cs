using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Review;
using api.Models;

namespace api.Mappers
{
    public static class ReviewMappers
    {
        public static ReviewDto ToReviewDto(this Review reviewModel)
        {
            return new ReviewDto
            {
                Id = reviewModel.Id,
                Rating = reviewModel.Rating,
                Comment = reviewModel.Comment,
                ProductId = reviewModel.ProductId
            };
        }

        public static Review ToReviewFromCreate(this CreateReviewDto reviewDto, int productId)
        {
            return new Review
            {
                Rating = reviewDto.Rating,
                Comment = reviewDto.Comment,
                ProductId = productId
            };
        }

        public static Review ToReviewFromUpdate(this UpdateReviewDto reviewDto)
        {
            return new Review
            {
                Rating = reviewDto.Rating,
                Comment = reviewDto.Comment,
            };
        }
    }
}