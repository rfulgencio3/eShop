using AutoMapper;
using eShop.ProductAPI.DTOs;
using eShop.ProductAPI.Models;
using eShop.ProductAPI.Repository;

namespace eShop.ProductAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task AddProduct(ProductDTO productDTO)
        {
            var productEntity = _mapper.Map<Product>(productDTO);
            await _repository.Create(productEntity);
            productDTO.ProductId = productEntity.ProductId;
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            var productEntity = await _repository.GetById(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task<ProductDTO> GetProductByName(string name)
        {
            var productEntity = await _repository.GetByName(name);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsEntity = await _repository.GetAll();
            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        }

        public async Task RemoveProduct(int id)
        {
            var productEntity = _repository.GetById(id).Result;
            await _repository.Delete(productEntity.ProductId);
        }

        public async Task UpdateProduct(ProductDTO productDTO)
        {
            var productEntity = _mapper.Map<Product>(productDTO);
            await _repository.Update(productEntity);
        }
    }
}
