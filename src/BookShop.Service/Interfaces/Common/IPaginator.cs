using BookShop.DataAccess.Utils;

namespace BookShop.Service.Interfaces.Common;

public interface IPaginator
{
    public void Paginate(long itemsCount, PaginationParams @params);

}
