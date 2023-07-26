using BookShop.Service.Interfaces.Auth;
using BookShop.Service.Interfaces.Books;
using BookShop.Service.Interfaces.Categories;
using BookShop.Service.Interfaces.Common;
using BookShop.Service.Interfaces.Notification;
using BookShop.Service.Services.Auth;
using BookShop.Service.Services.Books;
using BookShop.Service.Services.Categories;
using BookShop.Service.Services.Common;
using BookShop.Service.Services.Notification;

namespace BookShop.WebApi.Configurations.Layers;

public static class ServiceLayerConfiguration
{
    public static void ConfigureServiceLayer(this WebApplicationBuilder builder)
    {
        //-> DI containers, IoC containers
        builder.Services.AddScoped<IFileService, FileService>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<IPaginator, Paginator>();
        builder.Services.AddSingleton<ISmsSender, SmsSender>();

        builder.Services.AddScoped<IBookService, BookService>();
    }
}
