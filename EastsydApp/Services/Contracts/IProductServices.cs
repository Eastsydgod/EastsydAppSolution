
//Done By Emmanuel James
using EastsydApp.Models.DTOs;

namespace EastsydApp.Services.Contracts
{
    public interface IProductServices
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetProduct(int id);
        Task<IEnumerable<ProductCategoryDto>> GetProductCategories();
        Task<IEnumerable<ProductDto>> GetItemsByCategory(int categoryId);
    }
}
