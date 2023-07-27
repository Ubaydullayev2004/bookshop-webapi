using BookShop.DataAccess.Interfaces;
using BookShop.DataAccess.Interfaces.Books;
using BookShop.DataAccess.Interfaces.Categories;
using BookShop.DataAccess.Interfaces.Discounts;
using BookShop.DataAccess.Interfaces.Users;
using BookShop.DataAccess.Repositories.Books;
using BookShop.DataAccess.Repositories.Categories;
using BookShop.DataAccess.Repositories.Discounts;
using BookShop.DataAccess.Repositories.Users;

namespace BookShop.WebApi.Configurations.Layers;

public static class DataAccessConfiguration
{
    public static void ConfigureDataAccess(this WebApplicationBuilder builder)
    {
        //-> DI containers, IoC containers
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<IUserRepasitory, UserRepository>();
        builder.Services.AddScoped<IBookRepasitory, BookRepasitory>();
        builder.Services.AddScoped<IDiscountRepasitory, DiscountRepasitory>();
    }
}
