namespace DataAccess;

public class UserModel
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }
}