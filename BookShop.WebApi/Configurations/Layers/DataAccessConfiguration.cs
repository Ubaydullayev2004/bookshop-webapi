using BookShop.DataAccess.Interfaces.Categories;
using BookShop.DataAccess.Interfaces.Users;
using BookShop.DataAccess.Repositories.Categories;
using BookShop.DataAccess.Repositories.Users;

namespace BookShop.WebApi.Configurations.Layers;

public static class DataAccessConfiguration
{
    public static void ConfigureDataAccess(this WebApplicationBuilder builder)
    {
        //-> DI containers, IoC containers
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<IUserRepasitory, UserRepository>();
    }
}
