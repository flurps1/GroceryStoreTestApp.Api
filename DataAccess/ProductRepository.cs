using Microsoft.EntityFrameworkCore;

namespace DataAccess
{

    public interface IProductRepository
    {
        Task CreateAsync(Product product, CancellationToken cancellationToken = default);
        Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task UpdateAsync(Product product, CancellationToken cancellationToken = default);
        Task RemoveAsync(Product product, CancellationToken cancellationToken = default);
    }

    internal class ProductRepository(AppContext context) : IProductRepository
    {
        public async Task CreateAsync(Product product, CancellationToken cancellationToken = default)
        {
            await context.Products.AddAsync(product, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await context.Products.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task UpdateAsync(Product product, CancellationToken cancellationToken = default)
        {
            context.Products.Update(product);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task RemoveAsync(Product product, CancellationToken cancellationToken = default)
        {
            context.Products.Remove(product);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}