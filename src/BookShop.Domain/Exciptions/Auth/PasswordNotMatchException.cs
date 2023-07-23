namespace BookShop.Domain.Exciptions.Auth;

public class PasswordNotMatchException : BadRequestException
{
	public PasswordNotMatchException()
	{
		TitleMessage = "Password is invalid!";
	}
}
