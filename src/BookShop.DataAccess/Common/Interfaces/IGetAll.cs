using BookShop.DataAccess.Utils;

namespace BookShop.DataAccess.Common.Interfaces;

public interface IGetAll<TModel>
{
    public Task<IList<TModel>> GetAllAsync(PaginationParams @params);

}
