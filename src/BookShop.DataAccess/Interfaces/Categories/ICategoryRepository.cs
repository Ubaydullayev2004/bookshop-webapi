using BookShop.DataAccess.Common.Interfaces;
using BookShop.Domain.Entities.Categories;

namespace BookShop.DataAccess.Interfaces.Categories;

public interface ICategoryRepository : IRepasitory<Categoriy, Categoriy>,
    IGetAll<Categoriy>
{

}

