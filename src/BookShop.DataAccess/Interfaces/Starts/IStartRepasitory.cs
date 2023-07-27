using BookShop.Domain.Entities.Starts;

namespace BookShop.DataAccess.Interfaces.Starts;

public interface IStartRepasitory:IRepasitory<Star,Star>
{
    public Task<int> CreateAsync(Star entity);
}
