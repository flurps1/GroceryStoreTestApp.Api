namespace DataAccess;

public interface IProductRepository
{
    Task CreateAsync(ProductsModel product, CancellationToken cancellationToken = default);
}