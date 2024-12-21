using DataAccess;

namespace BusinessLogic
{
    internal class ProductService(IProductRepository productRepository) : IProductService
    {
        public async Task<IEnumerable<ProductModel?>> GetAllProductsAsync(CancellationToken cancellationToken = default)
        {
            return await productRepository.GetAllProductsAsync(cancellationToken);
        }

        public async Task CreateAsync(string name, string imageUrl, int quantity, CancellationToken cancellationToken)
        {
            var product = new ProductModel
            {
                Name = name,
                ImageUrl = imageUrl,
                Quantity = quantity
            };
            await productRepository.CreateAsync(product, cancellationToken);
        }

        public async Task<ProductModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var product = await productRepository.GetByIdAsync(id, cancellationToken);
            if (product is null)
            {
                throw new Exception("ProductModel is not available");
            }

            return product;
        }

        public async Task UpdateAsync(int id, string newName, CancellationToken cancellationToken = default)
        {
            var product = await productRepository.GetByIdAsync(id, cancellationToken);
            if (product is null)
            {
                throw new Exception("ProductModel is not available");
            }

            product.Name = newName;
            await productRepository.UpdateAsync(product, cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var product = await productRepository.GetByIdAsync(id, cancellationToken);
            if (product is null)
            {
                throw new Exception("ProductModel is not available");
            }

            await productRepository.RemoveAsync(product, cancellationToken);
        }
    }
}