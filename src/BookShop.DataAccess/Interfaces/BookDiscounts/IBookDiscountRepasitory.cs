using BookShop.DataAccess.Common.Interfaces;
using BookShop.Domain.Entities.BookDiscounts;

namespace BookShop.DataAccess.Interfaces.BookDiscounts;

public interface IBookDiscountRepasitory:IRepasitory<BookDiscount, BookDiscount>,
    IGetAll<BookDiscount>
{

}
