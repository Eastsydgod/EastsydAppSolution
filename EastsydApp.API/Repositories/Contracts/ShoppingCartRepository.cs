
//Done By Emmanuel James
using EastsydApp.API.Data;
using EastsydApp.API.Models;
using EastsydApp.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EastsydApp.API.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly EastsydDbContext eastSydDbContext;

        public ShoppingCartRepository(EastsydDbContext shopOnlineDbContext)
        {
            eastSydDbContext = shopOnlineDbContext;
        }

        private async Task<bool> CartItemExists(int cartId, int productId)
        {
            return await eastSydDbContext.CartItems.AnyAsync(c => c.CartId == cartId &&
                                                                     c.ProductId == productId);

        }
        public async Task<CartItem> AddItem(CartItemToAddDto cartItemToAddDto)
        {
            if (await CartItemExists(cartItemToAddDto.CartId, cartItemToAddDto.ProductId) == false)
            {
                var item = await (from product in eastSydDbContext.Products
                                  where product.Id == cartItemToAddDto.ProductId
                                  select new CartItem
                                  {
                                      CartId = cartItemToAddDto.CartId,
                                      ProductId = product.Id,
                                      Qty = cartItemToAddDto.Qty
                                  }).SingleOrDefaultAsync();

                if (item != null)
                {
                    var result = await eastSydDbContext.CartItems.AddAsync(item);
                    await eastSydDbContext.SaveChangesAsync();
                    return result.Entity;
                }
            }

            return null;

        }

        public async Task<CartItem> DeleteItem(int id)
        {
            var item = await eastSydDbContext.CartItems.FindAsync(id);

            if (item != null)
            {
                eastSydDbContext.CartItems.Remove(item);
                await eastSydDbContext.SaveChangesAsync();
            }

            return item;

        }

        public async Task<CartItem> GetItem(int id)
        {
            return await (from cart in eastSydDbContext.Carts
                          join cartItem in eastSydDbContext.CartItems
                          on cart.Id equals cartItem.CartId
                          where cartItem.Id == id
                          select new CartItem
                          {
                              Id = cartItem.Id,
                              ProductId = cartItem.ProductId,
                              Qty = cartItem.Qty,
                              CartId = cartItem.CartId
                          }).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<CartItem>> GetItems(int userId)
        {
            return await (from cart in eastSydDbContext.Carts
                          join cartItem in eastSydDbContext.CartItems
                          on cart.Id equals cartItem.CartId
                          where cart.UserId == userId
                          select new CartItem
                          {
                              Id = cartItem.Id,
                              ProductId = cartItem.ProductId,
                              Qty = cartItem.Qty,
                              CartId = cartItem.CartId
                          }).ToListAsync();
        }

        public async Task<CartItem> UpdateQty(int id, CartItemQtyUpdateDto cartItemQtyUpdateDto)
        {
            var item = await eastSydDbContext.CartItems.FindAsync(id);

            if (item != null)
            {
                item.Qty = cartItemQtyUpdateDto.Qty;
                await eastSydDbContext.SaveChangesAsync();
                return item;
            }

            return null;
        }
    }
}
