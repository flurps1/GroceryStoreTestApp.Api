using DataAccess;

namespace BusinessLogic;

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<IEnumerable<UserModel>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await userRepository.GetAllAsync(cancellationToken);
    }

    public async Task<UserModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var user = await userRepository.GetByIdAsync(id, cancellationToken);
        if (user == null)
        {
            throw new Exception("User not found.");
        }

        return user;
    }

    public async Task<UserModel?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await userRepository.GetByEmailAsync(email, cancellationToken);
    }

    public async Task CreateAsync(UserModel user, CancellationToken cancellationToken = default)
    {
        await userRepository.CreateAsync(user, cancellationToken);
    }

    public async Task UpdateAsync(UserModel user, CancellationToken cancellationToken = default)
    {
        await userRepository.UpdateAsync(user, cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var user = await userRepository.GetByIdAsync(id, cancellationToken);
        if (user == null)
        {
            throw new Exception("User not found.");
        }

        await userRepository.RemoveAsync(user, cancellationToken);
    }
}