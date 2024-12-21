using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public interface IUserRepository : IRepository<UserModel>
{
    Task<UserModel?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
}

public class UserRepository(AppContext context) : Repository<UserModel>(context), IUserRepository
{
    private readonly AppContext _context = context;

    public async Task<UserModel?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
    }
}