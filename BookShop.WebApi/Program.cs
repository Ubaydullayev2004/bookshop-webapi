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
using BookShop.WebApi.Configurations.Layers;
using BookShop.WebApi.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();

builder.ConfigureJwtAuth();
builder.ConfigureSwaggerAuth();
builder.ConfigureCORSPolicy();
builder.ConfigureDataAccess();
builder.ConfigureServiceLayer();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
