using BookShop.DataAccess.Interfaces.BookDiscounts;
using BookShop.DataAccess.Utils;
using BookShop.Domain.Entities.BookDiscounts;

namespace BookShop.DataAccess.Repositories.BookDiscounts;

public class BookDiscountRepasitory : BaseRepasitory, IBookDiscountRepasitory
{
    public Task<int> CreateAsync(BookDiscount entity)
    {
        throw new NotImplementedException();
    }

    public Task<int> DelateAsync(long bookDiscountId)
    {
        throw new NotImplementedException();
    }

    public Task<IList<BookDiscount>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<(int ItemsCount, IList<BookDiscount>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }
}

