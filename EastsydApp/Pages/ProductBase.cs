
//Done By Emmanuel James
using EastsydApp.Models.DTOs;
using EastsydApp.Services;
using EastsydApp.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace EastsydApp.Pages
{
    public class ProductBase : ComponentBase
    {
        [Inject]
        public IProductServices ProductService { get; set; }

        [Inject]
        public IShoppingCartServices ShoppingCartService { get; set; }

        [Inject]
        public IManageProductsLocalStorageService ManageProductsLocalStorageService { get; set; }

        [Inject]
        public IManageCartItemsLocalStorageService ManageCartItemsLocalStorageService { get; set; }

        public IEnumerable<ProductDto> Products { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public string ErrorMessage { get; set; }
        public string SearchTerm { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await ClearLocalStorage();

                Products = await ManageProductsLocalStorageService.GetCollection();

                var shoppingCartItems = await ManageCartItemsLocalStorageService.GetCollection();

                var totalQty = shoppingCartItems.Sum(i => i.Qty);

                ShoppingCartService.RaiseEventOnShoppingCartChanged(totalQty);

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;

            }

        }

        protected IOrderedEnumerable<IGrouping<int, ProductDto>> GetGroupedProductsByCategory()
        {
            var filteredProducts = string.IsNullOrWhiteSpace(SearchTerm)
                ? Products
                : Products.Where(p => p.Name.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase));

            return from product in filteredProducts
                   group product by product.ProductCategoryId into prodByCatGroup
                   orderby prodByCatGroup.Key
                   select prodByCatGroup;
        }

        protected string GetCategoryName(IGrouping<int, ProductDto> groupedProductDtos)
        {
            return groupedProductDtos.FirstOrDefault(pg => pg.ProductCategoryId == groupedProductDtos.Key).CategoryName;
        }

        private async Task ClearLocalStorage()
        {
            await ManageProductsLocalStorageService.RemoveCollection();
            await ManageCartItemsLocalStorageService.RemoveCollection();
        }

    }
}
