using AutoMapper;
using eShop.ProductAPI.DTOs;
using eShop.ProductAPI.Models;
using eShop.ProductAPI.Repository;

namespace eShop.ProductAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddCategory(CategoryDTO categoryDTO)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDTO);
            await _repository.Create(categoryEntity);
            categoryDTO.CategoryId = categoryEntity.CategoryId;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categoriesEntity = await _repository.GetAll();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesProducts()
        {
            var categoriesEntity = await _repository.GetCategoriesProducts();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task<CategoryDTO> GetCategoryById(int id)
        {
            var categoriesEntity = await _repository.GetById(id);
            return _mapper.Map<CategoryDTO>(categoriesEntity);
        }

        public async Task<CategoryDTO> GetCategoryByName(string name)
        {
            var categoriesEntity = await _repository.GetByName(name);
            return _mapper.Map<CategoryDTO>(categoriesEntity);
        }

        public async Task RemoveCategory(int id)
        {
            var categoryEntity = _repository.GetById(id).Result;
            await _repository.Delete(categoryEntity.CategoryId);
        }

        public async Task UpdateCategory(CategoryDTO categoryDTO)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDTO);
            await _repository.Update(categoryEntity);
        }
    }
}
