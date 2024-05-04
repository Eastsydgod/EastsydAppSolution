
//Done By Emmanuel James
using Microsoft.AspNetCore.Components;
using EastsydApp.Models.DTOs;
namespace EastsydApp.Pages
{
    public class DisplayProductsBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
