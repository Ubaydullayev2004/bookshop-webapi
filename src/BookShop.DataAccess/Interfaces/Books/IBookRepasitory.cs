using BookShop.DataAccess.Common.Interfaces;
using BookShop.DataAccess.ViewModel.Books;
using BookShop.Domain.Entities.Books;

namespace BookShop.DataAccess.Interfaces.Books;

public interface IBookRepasitory:IRepasitory<Book,BookViewModel>,IGetAll<BookViewModel>,ISearchable<BookViewModel>
{

}
