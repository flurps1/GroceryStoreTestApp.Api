namespace DataAccess;

internal class ProductRepository(AppContext context) : IProductRepository
{
    public async Task CreateAsync(ProductsModel product, CancellationToken cancellationToken = default)
    {
        await context.Products.AddAsync(product, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
}