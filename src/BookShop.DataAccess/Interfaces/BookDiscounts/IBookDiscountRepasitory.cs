using BookShop.DataAccess.Common.Interfaces;
using BookShop.Domain.Entities.BookDiscounts;

namespace BookShop.DataAccess.Interfaces.BookDiscounts;

public interface IBookDiscountRepasitory:IGetAll<BookDiscount>,ISearchable<BookDiscount>
{
    public Task<int> CreateAsync(BookDiscount entity);

    public Task<int> DelateAsync(long bookDiscountId);
}
