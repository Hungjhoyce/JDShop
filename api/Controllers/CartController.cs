using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Cart;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepo;
        public CartController(ICartRepository cartRepo)
        {
            _cartRepo = cartRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var carts = await _cartRepo.GetAllAsync();

            var cartDto = carts.Select(s => s.ToCartDto());

            return Ok(carts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var cart = await _cartRepo.GetByIdAsync(id);

            if(cart == null)
            {
                return NotFound();
            }

            return Ok(cart.ToCartDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCartRequestDto cartDto)
        {
            var cartModel = cartDto.ToCartFromCreate();
            await _cartRepo.CreateAsync(cartModel);

            return CreatedAtAction(nameof(GetById), new {id = cartModel.Id}, cartModel.ToCartDto());
        }


    }
}