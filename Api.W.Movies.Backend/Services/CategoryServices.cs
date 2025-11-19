using Api.W.Movies.Backend.DAL.Models;
using Api.W.Movies.Backend.DAL.Models.Dtos;
using Api.W.Movies.Backend.Repository.IRepository;
using Api.W.Movies.Backend.Services.IServices;
using AutoMapper;
using System.Data;

namespace Api.W.Movies.Backend.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryServices(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public Task<bool> CategotyExistsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryDto> CreateCategoryAsync(CategoryCreateDto categoryCreateDto)
        {
            //validar si la categoria exite

           var categoryExist= await _categoryRepository.CategoryExistsByNameAsync(categoryCreateDto.Name.ToLower());

            if (categoryExist)
            {
                throw new InvalidOperationException($"Ya existe una categoria con el nombre de '{categoryCreateDto.Name}´");
            }


            //Mapear el dto a la entidad

            var category= _mapper.Map<Category>(categoryCreateDto);

            var categoryCreate = await _categoryRepository.CreateCategoryAsync(category);

            if (!categoryCreate)
            {
                throw new Exception("Ocurrio un error al crear la categoria");
            }

            return _mapper.Map<CategoryDto>(category);
        }

        public Task<bool> DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<CategoryDto>> GetCategoryAsync()
        {
            var categories = await _categoryRepository.GetCategoryAsync();

            return _mapper.Map<ICollection<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetCategoryAsync(int id)
        {
            var categories = await _categoryRepository.GetCategoryAsync(id);
            return _mapper.Map<CategoryDto>(categories);
        }

        public async Task<CategoryDto> GetCategoryAsync(string name)
        {
            var category= await _categoryRepository.GetCategoryAsync(name);

            return _mapper.Map<CategoryDto>(category);
        }

        public Task<bool> GetCategoyExistsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDto> UpdateCategoryAsync(int id, CategoryDto categoryDto)
        {
            throw new NotImplementedException();
        }
    }
}