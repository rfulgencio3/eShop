using eShop.Web.Models;

namespace eShop.Web.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetAllProducts();
        Task<ProductViewModel> GetProductById(int id);
        Task<ProductViewModel> GetProductByName(string name);  
        Task<ProductViewModel> CreateProduct(ProductViewModel product);
        Task<ProductViewModel> UpdateProduct(ProductViewModel product);
        Task<bool> DeleteProductById(int id);
    }
}
