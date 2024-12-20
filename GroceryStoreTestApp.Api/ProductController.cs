using BussinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace GroceryStoreTestApp.Api;

[ApiController]
[Route("Product")]
public class ProductController(IProductService productService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddProduct(string name, string imageUrl, int quantity)
    {
        await productService.CreateAsync(name, imageUrl, quantity);
        return NoContent();
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetProductAsync([FromRoute] int id)
    {
        var res = await productService.GetById(id);
        return Ok(res);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateProductAsync([FromRoute] int id, string newName)
    {
        await productService.UpdateAsync(id, newName);
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> RemoveProductAsync([FromRoute] int id)
    {
        await productService.RemoveAsync(id);
        return Ok();
    }
        
}