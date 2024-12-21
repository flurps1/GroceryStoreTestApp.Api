namespace GroceryStoreTestApp.Api;

public class CreateCartItemDto
{
    public int UserId { get; set; } // Id пользователя
    public List<CreateCartItemDetailDto> Items { get; set; } // Список продуктов
}