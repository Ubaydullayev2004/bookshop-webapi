using BookShop.DataAccess.Utils;
using BookShop.Domain.Entities.Categories;
using BookShop.Service.Dtos.Categories;

namespace BookShop.Service.Interfaces.Categories;

public interface ICategoryService
{
    public Task<bool> CreateAsync(CategoryCreateDto dto);

    public Task<bool> DeleteAsync(long categoryId);

    public Task<long> CountAsync();

    public Task<IList<Categoriy>> GetAllAsync(PaginationParams @params);

    public Task<Categoriy> GetByIdAsync(long categoryId);

    public Task<bool> UpdateAsync(long categoryId, CategoryUpdateDto dto);
}