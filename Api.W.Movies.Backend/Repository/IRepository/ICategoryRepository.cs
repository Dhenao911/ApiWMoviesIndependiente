using Api.W.Movies.Backend.DAL.Models;

namespace Api.W.Movies.Backend.Repository.IRepository;

public interface ICategoryRepository
{
    Task<ICollection<Category>> GetCategoryAsync();//Me retorna una lista de categorias

    Task<Category> GetCategoryAsync(int id); //Me retorna una categoria por id

    Task<Category> GetCategoryAsync(string name); //Me retorna una categoria por name


    Task<bool> CategoryExistsByIdAsync(int id);//Me verifica si una categoria existe por id

    Task<bool> CategoryExistsByNameAsync(string name);//Me verifica si una categoria existe por id

    Task<bool> CreateCategoryAsync(Category category);//Me crea una categoria

    Task<bool> UpdateCategoryAsync(Category category);//Me actualiza una categoria

    Task<bool> DeleteCategoryAsync(int id);//Me elimina una categoria
}