namespace BookShop.DataAccess.Interfaces;

public interface IRepasitory<TEntity, TViewModel>
{

    public Task<int> CreateAsync(TEntity entity);

    public Task<int> UpdateAsync(long id, TEntity entity);

    public Task<int> DeleteAsync(long id);

    public Task<TViewModel?> GetByIdAsync(long id);


    public Task<long> CountAsync();
}
