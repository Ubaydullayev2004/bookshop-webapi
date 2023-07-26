using BookShop.DataAccess.Common.Interfaces;
using BookShop.Domain.Entities.Books;

namespace BookShop.DataAccess.Interfaces.Books;

public interface IBookRepasitory:IRepasitory<Book,Book>,IGetAll<Book>,ISearchable<Book>
{

}
