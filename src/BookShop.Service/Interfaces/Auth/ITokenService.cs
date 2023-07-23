using BookShop.Domain.Entities.Users;

namespace BookShop.Service.Interfaces.Auth;

public interface ITokenService
{
    public Task<string> GenerateToken(User user);

}
