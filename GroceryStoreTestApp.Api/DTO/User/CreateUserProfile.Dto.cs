namespace GroceryStoreTestApp.Api;

public class CreateUserProfileDto
{
    public string Username { get; set; }   // Имя пользователя
    public string Email { get; set; }      // Почта
    public string Phone { get; set; }      // Телефон
    public string Password { get; set; }   // Пароль (хэшируется в сервисе)
}