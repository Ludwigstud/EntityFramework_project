using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkTest.Models.Entities;


internal class ProductEntity
{
    [Key]
    public string ArticleNumber { get; set; } = null!;

    [Required]
    [Column(TypeName = "NVARCHAR(200)")]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }
    
    [Required]
    [Column(TypeName = "MONEY")]
    public decimal StockPrice { get; set; }


    public int CategoryId { get; set; }
    public CategoryEntity Category { get; set; } = null!;


}

