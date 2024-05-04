
//Done By Emmanuel James
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EastsydApp.Models.DTOs
{
    public class ProductCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconCss { get; set; }
        public ICollection<ProductDto> Products { get; set; }
    }
}
