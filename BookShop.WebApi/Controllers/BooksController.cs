using BookShop.DataAccess.Utils;
using BookShop.Service.Dtos.Books;
using BookShop.Service.Interfaces.Books;
using BookShop.Service.Validators.Books;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.WebApi.Controllers;

[Route("api/books")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly int maxPageSize = 6;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }


    [HttpGet]
    [AllowAnonymous]

    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _bookService.GetAllAsync(new PaginationParams(page, maxPageSize)));

    [HttpGet("{bookId}")]
    [AllowAnonymous]

    public async Task<IActionResult> GetByIdAsync(long bookId)
      => Ok(await _bookService.GetByIdAsync(bookId));

    [HttpGet("count")]
    [AllowAnonymous]

    public async Task<IActionResult> CountAsync()
        => Ok(await _bookService.CountAsync());

    [HttpPost]
   // [Authorize(Roles = "Admin")]

    public async Task<IActionResult> CreateAsync([FromForm] BookCreateDto dto)
    {
        var createValidator = new BookCreateValidator();
        var result = createValidator.Validate(dto);
        if (result.IsValid) return Ok(await _bookService.CreateAsync(dto));
        else return BadRequest(result.Errors);
    }

    [HttpPut("{bookId}")]
 //   [Authorize(Roles = "Admin")]

    public async Task<IActionResult> UpdateAsync(long bookId, [FromForm] BookUpdateDto dto)
    {
        var updateValidator = new BookUpdateValidator();
        var validationResult = updateValidator.Validate(dto);
        if (validationResult.IsValid) return Ok(await _bookService.UpdateAsync(bookId, dto));
        else return BadRequest(validationResult.Errors);
    }

    [HttpDelete("{bookId}")]
 //   [Authorize(Roles = "Admin")]

    public async Task<IActionResult> DeleteAsync(long bookId)
        => Ok(await _bookService.DeleteAsync(bookId));
}
