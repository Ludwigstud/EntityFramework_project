using EntityFrameworkTest.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTest.Contexts;
internal class DataContext : DbContext
{

    #region constructors and overrides

    public DataContext()
    {
        
    }

    public DataContext(DbContextOptions options) : base(options)
    {



    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\skol\kod\c#\EntityFramework_Project\EntityFrameworkTest\Contexts\EntityFrameworkDatabase.mdf;Integrated Security=True;Connect Timeout=30");
    }

    #endregion







    public DbSet<ProductEntity> Products { get; set; }

    public DbSet<CategoryEntity> Categories { get; set; }






}
