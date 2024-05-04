using EastsydApp.Models.DTOs;
using EastsydApp.Services.Contracts;
using Microsoft.AspNetCore.Components;

//Done By Emmanuel James
namespace EastsydApp.Shared
{
    public class ProductsCategoryNavMenuBase : ComponentBase
    {
        [Inject]
        public IProductServices ProductServices { get; set; }

        public IEnumerable<ProductCategoryDto> ProductCategoryDtos { get; set; }

        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                ProductCategoryDtos = await ProductServices.GetProductCategories();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
