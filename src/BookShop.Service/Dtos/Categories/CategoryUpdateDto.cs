﻿using Microsoft.AspNetCore.Http;

namespace BookShop.Service.Dtos.Categories;

public class CategoryUpdateDto
{
    public string Name { get; set; } = String.Empty;

    public string Description { get; set; } = String.Empty;

    public IFormFile? Image { get; set; }
}
