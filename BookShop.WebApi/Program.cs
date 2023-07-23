using BookShop.DataAccess.Interfaces.Categories;
using BookShop.DataAccess.Interfaces.Users;
using BookShop.DataAccess.Repositories.Categories;
using BookShop.DataAccess.Repositories.Users;
using BookShop.Service.Interfaces.Auth;
using BookShop.Service.Interfaces.Categories;
using BookShop.Service.Interfaces.Common;
using BookShop.Service.Interfaces.Notification;
using BookShop.Service.Services.Auth;
using BookShop.Service.Services.Categories;
using BookShop.Service.Services.Common;
using BookShop.Service.Services.Notification;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();




builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUserRepasitory, UserRepository>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddSingleton<ISmsSender, SmsSender>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
