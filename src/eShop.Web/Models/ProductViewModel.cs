using System.ComponentModel.DataAnnotations;

namespace eShop.Web.Models;

public class ProductViewModel
{
    public int ProductId { get; set; }
    [Required]
    public string Name { get; private set; }
    [Required]
    public decimal Price { get; private set; }
    public string? Description { get; private set; }
    [Required]
    public long Stock { get; private set; }
    [Required]
    public string? ImageUrl { get; private set; }
    public string? CategoryName { get; private set; }
    [Display(Name="Categorias")]
    public int CategoryId { get; private set; }
}

