namespace GroceryStoreTestApp.Api;

public class UpdateProductDto
{
    public int Id { get; set; }               
    public string Name { get; set; }          
    public string ImageUrl { get; set; }      
    public int Quantity { get; set; }         
}