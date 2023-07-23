namespace BookShop.Domain.Exciptions.Users;


public class UserCacheDataExpiredException : ExpiredException
{
	public UserCacheDataExpiredException()
	{
		TitleMessage = "User data has expired!";
	}
}
