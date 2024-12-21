using DataAccess;

namespace BusinessLogic;

public interface ICartService : IServiceBase<CartItemModel>
{
    Task<IEnumerable<CartItemModel>> GetByUserIdAsync(int userId, CancellationToken cancellationToken = default);
}