using AutoMapper;
using BusinessLogic;
using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace GroceryStoreTestApp.Api;

[ApiController]
[Route("CartItems")]
public class CartItemController(ICartService cartService, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllCartsAsync()
    {
        var carts = await cartService.GetAllAsync();
        var cartsDto = mapper.Map<IEnumerable<CartItemDto>>(carts);
        return Ok(cartsDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCartAsync([FromRoute] int id)
    {
        var cart = await cartService.GetByIdAsync(id);
        if (cart == null)
            return NotFound();

        var cartDto = mapper.Map<CartItemDto>(cart);
        return Ok(cartDto);
    }

    [HttpPost]
    public async Task<IActionResult> AddCartAsync([FromBody] CreateCartItemDto dto)
    {
        var cartItems = dto.Items.Select(item => new CartItemModel
        {
            UserId = dto.UserId,
            ProductId = item.ProductId,
            Quantity = item.Quantity
        });

        foreach (var item in cartItems)
        {
            await cartService.CreateAsync(item);
        }

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCartAsync([FromRoute] int id, [FromBody] UpdateCartItemDto dto)
    {
        foreach (var item in dto.Items)
        {
            var cartItem = new CartItemModel
            {
                Id = id, // Для обновления существующего
                ProductId = item.ProductId,
                Quantity = item.Quantity
            };

            await cartService.UpdateAsync(cartItem);
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCartAsync([FromRoute] int id)
    {
        await cartService.DeleteAsync(id);
        return NoContent();
    }
}