using BookShop.DataAccess.Common.Interfaces;
using BookShop.DataAccess.ViewModel.Users;
using BookShop.Domain.Entities.Users;

namespace BookShop.DataAccess.Interfaces.Users;

public interface IUserRepasitory: IRepasitory<User, UserViewModel>,
    IGetAll<User>, ISearchable<User>
{
    public Task<User?> GetByPhoneAsync(string phone);

}
