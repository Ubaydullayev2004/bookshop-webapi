using BookShop.DataAccess.Utils;
using BookShop.Domain.Entities.Books;
using BookShop.Service.Dtos.Books;

namespace BookShop.Service.Interfaces.Books;

public interface IBookService
{
    public Task<bool> CreateAsync(BookCreateDto dto);

    public Task<bool> UpdateAsync(long id,BookUpdateDto dto);

    public Task<bool> DeleteAsync(long bookId);

    public Task<long> CountAsync();

    public Task<List<Book>> GetAllAsync(PaginationParams @params);

    public Task<Book> GetByIdAsync(long BookId);
}
