﻿namespace BookShop.Domain.Exciptions.Users;

public class UserNotFoundException : NotFoundException
{
	public UserNotFoundException()
	{
		this.TitleMessage = "User not found";
	}
}
