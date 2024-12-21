using DataAccess;

namespace BusinessLogic;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<UserModel>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _userRepository.GetAllAsync(cancellationToken);
    }

    public async Task<UserModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(id, cancellationToken);
        if (user == null)
        {
            throw new Exception("User not found.");
        }

        return user;
    }

    public async Task<UserModel?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await _userRepository.GetByEmailAsync(email, cancellationToken);
    }

    public async Task CreateAsync(UserModel user, CancellationToken cancellationToken = default)
    {
        await _userRepository.CreateAsync(user, cancellationToken);
    }

    public async Task UpdateAsync(UserModel user, CancellationToken cancellationToken = default)
    {
        await _userRepository.UpdateAsync(user, cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(id, cancellationToken);
        if (user == null)
        {
            throw new Exception("User not found.");
        }

        await _userRepository.RemoveAsync(user, cancellationToken);
    }
}