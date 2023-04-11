using EntityFrameworkTest.Contexts;
using EntityFrameworkTest.Models.Entities;
using EntityFrameworkTest.Models.Forms;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace EntityFrameworkTest.Services;




internal class ProductService
{

    private readonly DataContext _context = new DataContext();
  private readonly CategoryService _categoryService = new CategoryService();






    public async Task<IEnumerable<ProductEntity>> GetAllAsync()
    {
        return await _context.Products.Include(c => c.Category).ToListAsync();



    }


    public async Task<ProductEntity> GetAsync(string articleNubmer)
    {
        var productEntity = await _context.Products.Include(c => c.Category).FirstOrDefaultAsync(a => a.ArticleNumber == articleNubmer);
        if (productEntity != null) 
        return productEntity;

        return null!;
        
        
    }


    public async Task DeleteAsync(string articleNumber)
    {

        var productEntity = await _context.Products.FirstOrDefaultAsync(a => a.ArticleNumber == articleNumber);
        if (productEntity != null)
        {
            _context.Remove(productEntity);
            await _context.SaveChangesAsync();
        }




    }

    public async Task<ProductEntity> CreateAsync(ProductRegistrationForm form)
    {
        if (await _context.Products.AnyAsync(a => a.ArticleNumber == form.ArticleNumber))
            return null!;


        var producteEntity = new ProductEntity()
        {
            ArticleNumber = form.ArticleNumber,
            Name = form.Name,
            Description = form.Description,
            StockPrice = form.StockPrice,
            CategoryId = (await _categoryService.GetOrCreateIfNotExistsAsync(form.CategoryName)).Id


        };

        _context.Add(producteEntity);
        await _context.SaveChangesAsync();
        return producteEntity;


    }

}
