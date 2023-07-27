using BookShop.DataAccess.Utils;
using BookShop.Service.Dtos.Categories;
using BookShop.Service.Dtos.Discount;
using BookShop.Service.Interfaces.Categories;
using BookShop.Service.Interfaces.Discounts;
using BookShop.Service.Validators.Categories;
using BookShop.Service.Validators.Discount;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.VisualStudio.Services.Notifications.VssNotificationEvent;

namespace BookShop.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DiscountController : ControllerBase
{
    private readonly IDiscountService _service;
    private readonly int maxPageSize = 6;
    public DiscountController(IDiscountService service)
    {
        this._service = service;
    }

    [HttpGet]
    [AllowAnonymous]

    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));


    [HttpGet("count")]
    [AllowAnonymous]

    public async Task<IActionResult> CountAsync()
        => Ok(await _service.CountAsync());

    [HttpPost]
    //[Authorize(Roles = "Admin")]

    public async Task<IActionResult> CreateAsync([FromForm] CreateDiscountDto dto)
    {
        var createValidator = new CreateDiscountValidator();
        var result = createValidator.Validate(dto);
        if (result.IsValid) return Ok(await _service.CreateAsync(dto));
        else return BadRequest(result.Errors);
    }

    
    [HttpDelete("{discountId}")]
    //[Authorize(Roles = "Admin")]

    public async Task<IActionResult> DeleteAsync(long categoryId)
        => Ok(await _service.DeleteAsync(categoryId));
}
