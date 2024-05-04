
//Done By Emmanuel James
using EastsydApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EastsydApp.API.Models
{
  
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconCss { get; set; } 
        public ICollection<Product> Products { get; set; }
    }
}
