namespace eShop.ProductAPI.Models;
public class Product
{
    public int ProductId { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public string? Description { get; private set; }
    public long Stock { get; private set; }
    public string? ImageUrl { get; private set; }

    public Category? Category { get; private set; }
    public int CategoryId { get; private set; }
}

