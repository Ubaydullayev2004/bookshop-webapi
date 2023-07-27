using BookShop.DataAccess.Interfaces.Books;
using BookShop.DataAccess.Utils;
using BookShop.Domain.Entities.Authors;
using BookShop.Domain.Entities.Books;
using BookShop.Domain.Entities.Categories;
using BookShop.Domain.Exciptions.Books;
using BookShop.Domain.Exciptions.Category;
using BookShop.Domain.Exciptions.Files;
using BookShop.Service.Dtos.Books;
using BookShop.Service.Interfaces.Books;
using BookShop.Service.Interfaces.Common;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualStudio.Services.WebApi;

namespace BookShop.Service.Services.Books;

public class BookService : IBookService
{
    private readonly IBookRepasitory _repository;
    private readonly IFileService _fileService;
    private readonly IMemoryCache _memoryCache;
    private readonly IPaginator _paginator;

    public BookService(IBookRepasitory repasitory,
        IFileService fileService,
        IMemoryCache memoryCache,
        IPaginator paginator)
    {
        this._repository = repasitory;
        this._fileService = fileService;
        this._memoryCache = memoryCache;
        this._paginator = paginator;
    }

    public Task<long> CountAsync() => _repository.CountAsync();

    public async Task<bool> CreateAsync(BookCreateDto dto)
    {
        string imagePath = await _fileService.UploadImageAsync(dto.Image);
        Book book = new Book()
        {
            ImagePath = imagePath,
            Title = dto.Title,
            Author = dto.Author,
            Description = dto.Description,
            CategoryID = dto.CategoryId,
            UnitPrice = dto.UnitPrice,
            ISBN = dto.ISBN,
            BookLanguage = dto.BookLanguage,
            Inscription = dto.Inscription,
            PageCount = dto.PageCount,
            Publisher = dto.Publisher,
            PaperFormat = dto.PaperFormat,
            YearOfPublication = dto.YearOfPublication,
            Cover = dto.Cover,
        };
        var result = await _repository.CreateAsync(book);
        return result > 0;
    }
    public async Task<bool> DeleteAsync(long bookId)
    {
        var book = await _repository.GetByIdAsync(bookId);
        if (book is null) throw new BookNotFoundException();
        
        var result = await _fileService.DeleteImageAsync(book.ImagePath);
        if (result == false) throw new ImageNotFoundException();

        var dbResult = await _repository.DeleteAsync(bookId);
        return dbResult > 0;

    }

    public async Task<List<Book>> GetAllAsync(PaginationParams @params)
    {
        var books = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);
        return (List<Book>)books;
    }

    public async Task<Book> GetByIdAsync(long BookId)
    {
        var book = await _repository.GetByIdAsync(BookId);
        if (book is null) throw new CategoryNotFoundException();
        return book;
    }

    public async Task<bool> UpdateAsync(long bookId,BookUpdateDto dto)
    {
        var book = await _repository.GetByIdAsync(bookId);
        if (book is null) throw new BookNotFoundException();

        // parse new items to book
        book.Title = dto.Title;
        book.Author = dto.Author;
        book.Description = dto.Description;
        book.CategoryID = dto.CategoryId;
        book.UnitPrice = dto.UnitPrice;
        book.ISBN = dto.ISBN;
        book.BookLanguage = dto.BookLanguage;
        book.Inscription = dto.Inscription;
        book.PageCount = dto.PageCount;
        book.Publisher = dto.Publisher;
        book.PaperFormat = dto.PaperFormat;
        book.YearOfPublication = dto.YearOfPublication;
        book.Cover = dto.Cover;

        if (dto.Image is not null)
        {
            // delete old image
            var deleteResult = await _fileService.DeleteImageAsync(book.ImagePath);
            if (deleteResult is false) throw new ImageNotFoundException();

            // upload new image
            string newImagePath = await _fileService.UploadImageAsync(dto.Image);

            // parse new path to category
            book.ImagePath = newImagePath;
        }
        var dbResult = await _repository.UpdateAsync(bookId, book);
        return dbResult > 0;
    }

}
