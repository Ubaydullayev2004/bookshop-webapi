using Microsoft.AspNetCore.Http;

namespace BookShop.Service.Dtos.Books;

public class BookUpdateDto
{
    public string Title { get; set; } = String.Empty;

    public string Author { get; set; } = String.Empty;

    public string Description { get; set; } = String.Empty;

    public int CategoryId { get; set; }

    public double UnitPrice { get; set; }

    public IFormFile Image { get; set; } = default!;

    public string ISBN { get; set; } = String.Empty;

    public string BookLanguage { get; set; } = String.Empty;

    public string Inscription { get; set; } = String.Empty;

    public int PageCount { get; set; }

    public string Publisher { get; set; } = String.Empty;

    public string Cover { get; set; } = String.Empty;

    public string PaperFormat { get; set; } = String.Empty;

    public int YearOfPublication { get; set; }
}
