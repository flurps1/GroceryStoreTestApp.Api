using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public interface ICartRepository : IRepository<CartItemModel>
{
    Task<IEnumerable<CartItemModel>> GetByUserIdAsync(int userId, CancellationToken cancellationToken = default);
}

public class CartRepository(AppContext context) : Repository<CartItemModel>(context), ICartRepository
{
    private readonly AppContext _context = context;

    public async Task<IEnumerable<CartItemModel>> GetByUserIdAsync(int userId, CancellationToken cancellationToken = default)
    {
        return await _context.CartItems
            .Where(c => c.UserId == userId)
            .ToListAsync(cancellationToken);
    }
}