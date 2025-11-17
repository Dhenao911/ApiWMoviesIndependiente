using Api.W.Movies.Backend.DAL;
using Api.W.Movies.Backend.DAL.Models;
using Api.W.Movies.Backend.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Api.W.Movies.Backend.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly AplicactionDbContext _context;

    public CategoryRepository(AplicactionDbContext context)
    {
        _context = context;
    }

    public async Task<ICollection<Category>> GetCategoryAsync()
    {
        return await _context.Categories
            .AsNoTracking()
            .OrderBy(c => c.Name)
            .ToListAsync();
    }

    public async Task<Category> GetCategoryAsync(int id)
    {
        return await _context.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<bool> CategoryExistsByIdAsync(int id)
    {
        return await _context.Categories
            .AsNoTracking()
            .AnyAsync(c => c.Id == id);
    }

    public async Task<bool> CategoryExistsByNameAsync(string name)
    {
        return await _context.Categories
               .AsNoTracking()
               .AnyAsync(C => C.Name == name);
    }

    public async Task<bool> CreateCategoryAsync(Category category)
    {
        category.CreateDate = DateTime.UtcNow;

        var categry = await _context.Categories.AddAsync(category);

        return await SaveAsync()
    }

    public async Task<bool> UpdateCategoryAsync(Category category)
    {
        category.ModifiedDate = DateTime.UtcNow;

        _context.Categories.Update(category);

        return await SaveAsync();
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        var category = await GetCategoryAsync(id);

        if ((category == null))
        {
            return false;
        }

        _context.Categories.Remove(category);

        return await SaveAsync();
    }

    private async Task<bool> SaveAsync()
    {
        return await _context.SaveChangesAsync() > 0 ? true : false;
    }
}