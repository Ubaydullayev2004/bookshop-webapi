using BookShop.DataAccess.Interfaces.Books;
using BookShop.DataAccess.Utils;
using BookShop.Domain.Entities.Books;
using Dapper;

namespace BookShop.DataAccess.Repositories.Books;

public class BookRepasitory : BaseRepasitory, IBookRepasitory
{
    public async  Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select count(*) from books";
            var result = await _connection.QuerySingleAsync<long>(query);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public  async Task<int> CreateAsync(Book entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.books(title, category_id, description, unit_price, image_path, isbn, author, book_language, inscription, page_count, publisher, cover, paper_format, year_of_publication, created_at, updated_at ) " +
                "VALUES ( @Title, @CategoryId, @Description, @UnitPrice, @ImagePath, @Isbn, @Author, @BookLanguage, @Inscription, @PageCount, @Publisher, @Cover, @PaperFormat, @YearOfPublication, @CreatedAt, @UpdatedAt );";
            var result = await _connection.ExecuteAsync(query, entity); 
            return result;
        }
        catch 
        {
            return 0;
        }
        finally
        {

        }
    }

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"DELETE FROM books WHERE id=@Id";
            var result = await _connection.ExecuteAsync(query, new { Id = id });
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<Book>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM books order by id desc " +

                $"offset {@params.GetSkipCount()} limit {@params.PageSize}";

            var result = (await _connection.QueryAsync<Book>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<Book>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<Book> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM books where id=@Id";
            var result = await _connection.QuerySingleAsync<Book>(query, new { Id = id });
            return result;
        }
        catch
        {
            return null;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
    public async Task<int> UpdateAsync(long id, Book entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"UPDATE public.books" +
            $"SET title=@Title, category_id=@CategoryId, description=@Description, unit_price=@UnitPrice, image_path=@ImagePath, isbn=@Isbn, author=@Author, book_language=@BookLanguage, inscription=@Inscription, page_count=@PageCount, publisher=@Publisher, cover=@Cover, paper_format=@PaperFormat, year_of_publication=@YearOfPublication, created_at=@CreatedAt, updated_at=@UpdatedAt" +
             $"WHERE id={id};";

            var result = await _connection.ExecuteAsync(query, entity);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<(int ItemsCount, IList<Book>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

}
