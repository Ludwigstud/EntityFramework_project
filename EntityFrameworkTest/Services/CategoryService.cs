using EntityFrameworkTest.Contexts;
using EntityFrameworkTest.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTest.Services;



internal class CategoryService
{
    private readonly DataContext _context = new DataContext();




    public async Task<CategoryEntity> GetOrCreateIfNotExistsAsync(string categoryName)
    {
        var categoryEntity = await _context.Categories.FirstOrDefaultAsync(c => c.Name == categoryName);
        if (categoryEntity == null)
        {
            categoryEntity = new CategoryEntity() { Name = categoryName };
            _context.Add(categoryEntity);
            await _context.SaveChangesAsync();
        }

        return categoryEntity;
    }



    public async Task<IEnumerable<CategoryEntity>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }



    public async Task DeleteAsync(string categoryName)
    {

        var categoryEntity = await _context.Categories.FirstOrDefaultAsync(c => c.Name == categoryName);
        if (categoryEntity != null)
        {
            _context.Remove(categoryEntity);
            await _context.SaveChangesAsync();
        }
    }


}