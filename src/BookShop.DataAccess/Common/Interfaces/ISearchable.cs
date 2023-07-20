using BookShop.DataAccess.Utils;

namespace BookShop.DataAccess.Common.Interfaces;

public interface ISearchable<TModel>
{
    public Task<(int ItemsCount, IList<TModel>)> SearchAsync(string search,
       PaginationParams @params);
}
