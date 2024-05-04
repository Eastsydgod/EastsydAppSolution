
//Done By Emmanuel James
using EastsydApp.Models.DTOs;

namespace EastsydApp.Services.Contracts
{
    public interface IManageProductsLocalStorageService
    {
        Task<IEnumerable<ProductDto>> GetCollection();
        Task RemoveCollection();
    }
}
