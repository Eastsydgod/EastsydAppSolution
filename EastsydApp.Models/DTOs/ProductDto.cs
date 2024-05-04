
//Done By Emmanuel James
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EastsydApp.Models.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public int ProductCategoryId { get; set; }
        public string CategoryName { get; set; }

        public ProductCategoryDto ProductCategory { get; set; }

    }
}
