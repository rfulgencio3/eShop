using eShop.Web.Models;
using eShop.Web.Services.Contracts;
using System.Text;
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

        public async Task<IEnumerable<ProductViewModel>> GetAllProducts()
        {
            var client = _clientFactory.CreateClient("ProductAPI");
            using (var response = await client.GetAsync(apiEndpoint))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    productsViewModel = await JsonSerializer
                                        .DeserializeAsync<IEnumerable<ProductViewModel>>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }
            return productsViewModel;
        }

        public async Task<ProductViewModel> GetProductById(int id)
        {
            var client = _clientFactory.CreateClient("ProductAPI");

            using (var response = await client.GetAsync(apiEndpoint + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    productViewModel = await JsonSerializer
                                        .DeserializeAsync<ProductViewModel>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }
            return productViewModel;
        }

        public async Task<ProductViewModel> GetProductByName(string name)
        {
            var client = _clientFactory.CreateClient("ProductAPI");

            using (var response = await client.GetAsync(apiEndpoint + name))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    productViewModel = await JsonSerializer
                                        .DeserializeAsync<ProductViewModel>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }
            return productViewModel;
        }

        public async Task<ProductViewModel> CreateProduct(ProductViewModel productViewModel)
        {
            var client = _clientFactory.CreateClient("ProductAPI");

            StringContent content = new StringContent(JsonSerializer.Serialize(productViewModel),
                                    Encoding.UTF8, "application/json");

            using (var response = await client.PostAsync(apiEndpoint, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    productViewModel = await JsonSerializer
                                        .DeserializeAsync<ProductViewModel>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }
            return productViewModel;
        }
        public async Task<ProductViewModel> UpdateProduct(ProductViewModel productViewModel)
        {
            var client = _clientFactory.CreateClient("ProductAPI");
            ProductViewModel productUdated = new ProductViewModel();

            using (var response = await client.PutAsJsonAsync(apiEndpoint, productViewModel))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    productUdated = await JsonSerializer
                                    .DeserializeAsync<ProductViewModel>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }
            return productUdated;
        }

        public async Task<bool> DeleteProductById(int id)
        {
            var client = _clientFactory.CreateClient("ProductAPI");

            using (var response = await client.DeleteAsync(apiEndpoint + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
