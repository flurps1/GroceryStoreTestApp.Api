namespace GroceryStoreTestApp.Api;

public class PasswordHasher
{
    private const int WorkFactor = 12;

    /// <summary>
    /// Hash password using BCrypt
    /// </summary>
    /// <param name="password">Password for hashing</param>
    /// <returns>Hash password</returns>
    public static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, WorkFactor);
    }

    /// <summary>
    /// Checks if the password matches its hash
    /// </summary>
    /// <param name="password">Verifiable password</param>
    /// <param name="hashedPassword">Password hash from database</param>
    /// <returns>true if the password matches the hash, otherwise false</returns>
    public static bool VerifyPassword(string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}