using DataAccess;

namespace BusinessLogic;

public interface IUserService : IServiceBase<UserModel>
{
    Task<UserModel?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
}