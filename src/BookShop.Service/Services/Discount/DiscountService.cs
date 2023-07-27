using BookShop.DataAccess.Interfaces;
using BookShop.DataAccess.Utils;
using BookShop.Domain.Entities.Categories;
using BookShop.Domain.Exciptions.Category;
using BookShop.Domain.Exciptions.Files;
using BookShop.Service.Common.Helpers;
using BookShop.Service.Dtos.Discount;
using BookShop.Service.Interfaces.Common;
using BookShop.Service.Interfaces.Discounts;
using Microsoft.Extensions.Caching.Memory;


namespace BookShop.Service.Services.Discount;

public class DiscountService : IDiscountService
{
    private readonly IDiscountRepasitory _repository;
    private readonly IFileService _fileService;
    private readonly IMemoryCache _memoryCache;
    private readonly IPaginator _paginator;

    public DiscountService(IDiscountRepasitory repasitory,
        IFileService fileService,
        IMemoryCache memoryCache,
        IPaginator paginator)
    {
        _repository = repasitory;
        _fileService = fileService;
        _memoryCache = memoryCache;
        _paginator = paginator;
    }

    public async Task<long> CountAsync() => await _repository.CountAsync();
    

    public async Task<bool> CreateAsync(DiscountDto dto)
    {
        Domain.Entities.Discounts.Discount discount = new Domain.Entities.Discounts.Discount
        {
            Name = dto.name,
            Description = dto.description,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime()
        };

        var result = await _repository.CreateAsync(discount);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(long discountId)
    {
        var discount = await _repository.GetByIdAsync(discountId);
        if ( discount is null) throw new CategoryNotFoundException();

        var dbResult = await _repository.DeleteAsync(discountId);
        return dbResult > 0;
    }

    public async Task<IList<Domain.Entities.Discounts.Discount>> GetAllAsync(PaginationParams @params)
    {
        var discount = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);
        return discount;
    }
}
