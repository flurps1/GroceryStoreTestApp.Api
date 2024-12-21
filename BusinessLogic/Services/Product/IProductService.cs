using DataAccess;

namespace BusinessLogic;

public interface IProductService
{
    Task<ProductModel> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<ProductModel?>> GetAllProductsAsync(CancellationToken cancellationToken = default);
    Task CreateAsync(string name, string imageUrl, int quantity, CancellationToken cancellationToken = default);
    Task UpdateAsync(int id, string newName, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}