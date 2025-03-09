
//Done By Emmanuel James
using EastsydApp;
using EastsydApp.Services.Contracts;
using EastsydApp.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);


builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configure HttpClient with environment-aware API URL
var baseUri = builder.HostEnvironment.IsDevelopment()
    ? new Uri("https://localhost:7251/")  // Local development URL
    : new Uri("https://eastsydappapi.azurewebsites.net/");  // Production API URL

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = baseUri });

builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<IShoppingCartServices, ShoppingCartServices>();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<IManageProductsLocalStorageService, ManageProductsLocalStorageService>();
builder.Services.AddScoped<IManageCartItemsLocalStorageService, ManageCartItemsLocalStorageService>();

await builder.Build().RunAsync();
