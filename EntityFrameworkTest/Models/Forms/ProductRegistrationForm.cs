using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTest.Models.Forms;
internal class ProductRegistrationForm
{




    public string ArticleNumber { get; set; } = null!;


    public string Name { get; set; } = null!;

    public string? Description { get; set; }


    public decimal StockPrice { get; set; }

    public string CategoryName { get; set; } = null!;

}
