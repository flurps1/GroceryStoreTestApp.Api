using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public interface IProductRepository
    {
        Task<ProductModel?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<ProductModel?>> GetAllProductsAsync(CancellationToken cancellationToken = default);
        Task CreateAsync(ProductModel productModel, CancellationToken cancellationToken = default);
        Task UpdateAsync(ProductModel productModel, CancellationToken cancellationToken = default);
        Task RemoveAsync(ProductModel productModel, CancellationToken cancellationToken = default);
    }

    internal class ProductRepository(AppContext context) : IProductRepository
    {
        public async Task<IEnumerable<ProductModel?>> GetAllProductsAsync(CancellationToken cancellationToken = default)
        {
            return await context.Products.ToListAsync(cancellationToken: cancellationToken);
        }


        public async Task<ProductModel?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await context.Products.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task CreateAsync(ProductModel productModel, CancellationToken cancellationToken = default)
        {
            await context.Products.AddAsync(productModel, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(ProductModel productModel, CancellationToken cancellationToken = default)
        {
            context.Products.Update(productModel);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task RemoveAsync(ProductModel productModel, CancellationToken cancellationToken = default)
        {
            context.Products.Remove(productModel);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}