using DataAccess;

namespace Business_Logic;

internal class ProductService(IProductService productService) : IProductService
{
    public async Task createAsync(string name, CancellationToken cancellationToken)
    {
        var product = new ProductsModel()
        {
            Name = name,
        };
        await productService.createAsync(name, cancellationToken);
    }
}