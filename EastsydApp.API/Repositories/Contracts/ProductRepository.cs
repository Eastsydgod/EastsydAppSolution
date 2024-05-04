
//Done By Emmanuel James
using EastsydApp.API.Data;
using EastsydApp.API.Models;

using Microsoft.EntityFrameworkCore;

namespace EastsydApp.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly EastsydDbContext eastsydDbContext;

        public ProductRepository(EastsydDbContext eastsydDbContext)
        {
            this.eastsydDbContext = eastsydDbContext;
        }
        public async Task<IEnumerable<ProductCategory>> GetCategories()
        {
            var categories = await eastsydDbContext.ProductCategories.ToListAsync();

            return categories;

        }

        public async Task<ProductCategory> GetCategory(int id)
        {
            var category = await eastsydDbContext.ProductCategories.SingleOrDefaultAsync(c => c.Id == id);
            return category;
        }

        public async Task<Product> GetItem(int id)
        {
            var product = await eastsydDbContext.Products
                                .Include(p => p.ProductCategory)
                                .SingleOrDefaultAsync(p => p.Id == id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetItems()
        {
            var products = await eastsydDbContext.Products
                                     .Include(p => p.ProductCategory).ToListAsync();

            return products;

        }

        public async Task<IEnumerable<Product>> GetItemsByCategory(int id)
        {
            var products = await eastsydDbContext.Products
                                     .Include(p => p.ProductCategory)
                                     .Where(p => p.ProductCategoryId == id).ToListAsync();
            return products;
        }
    }
}
