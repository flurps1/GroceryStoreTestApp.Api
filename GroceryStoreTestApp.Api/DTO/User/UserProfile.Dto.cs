namespace GroceryStoreTestApp.Api;

public class UserProfileDto
{
    public int Id { get; set; }             // Id пользователя
    public string Username { get; set; }   // Имя пользователя
    public string Email { get; set; }      // Почта
    public string Phone { get; set; }      // Телефон
    public string Role { get; set; }       // Роль пользователя
}