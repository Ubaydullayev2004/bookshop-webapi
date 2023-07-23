namespace BookShop.Domain.Exciptions.Auth;

public class VerificationCodeExpiredException : ExpiredException
{
	public VerificationCodeExpiredException()
	{
		TitleMessage = "Verification code is expired!";
	}
}
