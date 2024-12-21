using DataAccess;

namespace BusinessLogic;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;

    public CartService(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<IEnumerable<CartItemModel>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _cartRepository.GetAllAsync(cancellationToken);
    }

    public async Task<CartItemModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var cartItem = await _cartRepository.GetByIdAsync(id, cancellationToken);
        if (cartItem == null)
        {
            throw new Exception("Cart item not found.");
        }

        return cartItem;
    }

    public async Task<IEnumerable<CartItemModel>> GetByUserIdAsync(int userId, CancellationToken cancellationToken = default)
    {
        return await _cartRepository.GetByUserIdAsync(userId, cancellationToken);
    }

    public async Task CreateAsync(CartItemModel cartItem, CancellationToken cancellationToken = default)
    {
        await _cartRepository.CreateAsync(cartItem, cancellationToken);
    }

    public async Task UpdateAsync(CartItemModel cartItem, CancellationToken cancellationToken = default)
    {
        await _cartRepository.UpdateAsync(cartItem, cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var cartItem = await _cartRepository.GetByIdAsync(id, cancellationToken);
        if (cartItem == null)
        {
            throw new Exception("Cart item not found.");
        }

        await _cartRepository.RemoveAsync(cartItem, cancellationToken);
    }
}