using DataAccess;

namespace BussinessLogic
{

    public interface IProductService
    {
        Task CreateAsync(string name, string imageUrl, int quantity, CancellationToken cancellationToken = default);
        Task<string> GetById(int id, CancellationToken cancellationToken = default);
        Task UpdateAsync(int id, string newName, CancellationToken cancellationToken = default);
        Task RemoveAsync(int id, CancellationToken cancellationToken = default);
    }

    internal class ProductService(IProductRepository productRepository) : IProductService
    {
        public async Task CreateAsync(string name, string imageUrl, int quantity, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                Name = name,
                ImageUrl = imageUrl,
                Quantity = quantity
            };
            await productRepository.CreateAsync(product, cancellationToken);
        }

        public async Task<string> GetById(int id, CancellationToken cancellationToken = default)
        {
            var product = await productRepository.GetByIdAsync(id, cancellationToken);
            if (product is null)
            {
                throw new Exception("Product is not available");
            }
            return product.Name;
        }

        public async Task UpdateAsync(int id, string newName, CancellationToken cancellationToken = default)
        {
            var product = await productRepository.GetByIdAsync(id, cancellationToken);
            if (product is null)
            {
                throw new Exception("Product is not available");
            }
            
            product.Name = newName;
            await productRepository.UpdateAsync(product, cancellationToken);
        }

        public async Task RemoveAsync(int id, CancellationToken cancellationToken = default)
        {
            var product = await productRepository.GetByIdAsync(id, cancellationToken);
            if (product is null)
            {
                throw new Exception("Product is not available");
            }

            await productRepository.RemoveAsync(product, cancellationToken);
        }
    }
}
