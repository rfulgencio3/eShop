using eShop.ProductAPI.DTOs;
using eShop.ProductAPI.Services;
using eShop.Web.Models;
using System.Text.Json;

namespace eShop.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string apiEndpoint = "/api/products/";
        private readonly JsonSerializerOptions _options;
        private ProductViewModel productViewModel;
        private IEnumerable<ProductViewModel> productsViewModel;
        public ProductService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public Task AddProduct(ProductDTO productDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> GetProductByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDTO>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task RemoveProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProduct(ProductDTO productDTO)
        {
            throw new NotImplementedException();
        }
    }
}
