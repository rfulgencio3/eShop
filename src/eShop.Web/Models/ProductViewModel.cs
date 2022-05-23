namespace eShop.Web.Models;

public class ProductViewModel
{
    public int ProductId { get; set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public string? Description { get; private set; }
    public long Stock { get; private set; }
    public string? ImageUrl { get; private set; }
    public string? CategoryName { get; private set; }
    public int CategoryId { get; private set; }
}

