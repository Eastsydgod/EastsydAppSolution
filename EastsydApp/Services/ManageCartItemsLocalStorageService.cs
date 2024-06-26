﻿
//Done By Emmanuel James
using Blazored.LocalStorage;
using EastsydApp.Models.DTOs;
using EastsydApp.Services.Contracts;

namespace EastsydApp.Services
{
    public class ManageCartItemsLocalStorageService : IManageCartItemsLocalStorageService
    {
        private readonly ILocalStorageService localStorageService;
        private readonly IShoppingCartServices shoppingCartService;

        const string key = "CartItemCollection";

        public ManageCartItemsLocalStorageService(ILocalStorageService localStorageService,
                                                  IShoppingCartServices shoppingCartService)
        {
            this.localStorageService = localStorageService;
            this.shoppingCartService = shoppingCartService;
        }

        public async Task<List<CartItemDto>> GetCollection()
        {
            return await this.localStorageService.GetItemAsync<List<CartItemDto>>(key)
                    ?? await AddCollection();
        }

        public async Task RemoveCollection()
        {
            await this.localStorageService.RemoveItemAsync(key);
        }

        public async Task SaveCollection(List<CartItemDto> cartItemDtos)
        {
            await this.localStorageService.SetItemAsync(key, cartItemDtos);
        }

        private async Task<List<CartItemDto>> AddCollection()
        {
            var shoppingCartCollection = await this.shoppingCartService.GetItems(HardCoded.UserId);

            if (shoppingCartCollection != null)
            {
                await this.localStorageService.SetItemAsync(key, shoppingCartCollection);
            }

            return shoppingCartCollection;

        }

    }
}
