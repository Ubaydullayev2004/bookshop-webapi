using BookShop.DataAccess.Common.Interfaces;
using BookShop.DataAccess.ViewModel.Users;
using BookShop.Domain.Entities.Users;

namespace BookShop.DataAccess.Interfaces.Users;

public interface IUserRepasitory: IRepasitory<User, UserViewModel>,
    IGetAll<UserViewModel>, ISearchable<UserViewModel>
{
    public Task<User?> GetByPhoneAsync(string phone);

}
