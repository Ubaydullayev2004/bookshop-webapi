using BookShop.DataAccess.Utils;
using BookShop.Domain.Entities.Categories;
using BookShop.Domain.Entities.Discounts;
using BookShop.Service.Dtos.Categories;
using BookShop.Service.Dtos.Discount;

namespace BookShop.Service.Interfaces.Discounts;

public interface IDiscountService
{
    public Task<bool> CreateAsync(CreateDiscountDto dto);

    public Task<long> CountAsync();

    public Task<IList<Discount>> GetAllAsync(PaginationParams @params);

    public Task<bool> DeleteAsync(long discountId);


}
