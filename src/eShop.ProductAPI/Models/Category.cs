namespace eShop.ProductAPI.Models;
public class Category
{
    public int CategoryId { get; private set; }
    public string? Name { get; set; }
    public ICollection<Product>? Products { get; set; }
}

