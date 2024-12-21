namespace GroceryStoreTestApp.Api
{
    public class CartItemDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class CreateCartItemDetailDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class UpdateCartItemDto
    {
        public List<UpdateCartItemDetailDto> Items { get; set; }
    }

    public class UpdateCartItemDetailDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}