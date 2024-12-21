using AutoMapper;
using BusinessLogic;
using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace GroceryStoreTestApp.Api;

[ApiController]
[Route("ProductModel")]
public class ProductController(IProductService productService, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllProductsAsync()
    {
        var products = await productService.GetAllProductsAsync();
        var productsDto = mapper.Map<IEnumerable<ProductDto>>(products);

        return Ok(productsDto);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductAsync([FromRoute] int id)
    {
        var product = await productService.GetByIdAsync(id);
        var productDto = mapper.Map<ProductDto>(product);
        return Ok(productDto);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] CreatedProductDto dto)
    {
        await productService.CreateAsync(dto.Name, dto.ImageUrl, dto.Quantity);
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProductAsync([FromRoute] int id, string newName)
    {
        await productService.UpdateAsync(id, newName);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductAsync(int id)
    {
        await productService.DeleteAsync(id);
        return NoContent();
    }
}