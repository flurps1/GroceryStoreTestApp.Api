namespace GroceryStoreTestApp.Api
{

    public class CartItemDto
    {
        public int Id { get; set; } // Id записи корзины
        public int UserId { get; set; } // Id пользователя
        public int ProductId { get; set; } // Id продукта
        public string ProductName { get; set; } // Название продукта
        public int Quantity { get; set; } // Количество продуктов
    }

// DTO для создания корзины


// DTO для создания отдельного продукта в корзине
    public class CreateCartItemDetailDto
    {
        public int ProductId { get; set; } // Id продукта
        public int Quantity { get; set; } // Количество
    }

// DTO для обновления корзины
    public class UpdateCartItemDto
    {
        public List<UpdateCartItemDetailDto> Items { get; set; } // Обновляемые продукты
    }

// DTO для обновления отдельного продукта в корзине
    public class UpdateCartItemDetailDto
    {
        public int ProductId { get; set; } // Id продукта
        public int Quantity { get; set; } // Новое количество
    }
}