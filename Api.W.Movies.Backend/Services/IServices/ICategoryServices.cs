using Api.W.Movies.Backend.DAL.Models;
using Api.W.Movies.Backend.DAL.Models.Dtos;

namespace Api.W.Movies.Backend.Services.IServices
{
    public interface ICategoryServices
    {
        Task<ICollection<CategoryDto>> GetCategoryAsync();

        Task<CategoryDto> GetCategoryAsync(int id);

        Task<CategoryDto  > GetCategoryAsync(string name);

        Task<bool> CategotyExistsByIdAsync(int id);

        Task<bool> GetCategoyExistsByNameAsync(string name);

        Task<bool> CreateCategoryAsync(Category category);

        Task<bool> UpdateCategoryAsync(Category category);

        Task<bool> DeleteCategoryAsync(int id);
    }
}
