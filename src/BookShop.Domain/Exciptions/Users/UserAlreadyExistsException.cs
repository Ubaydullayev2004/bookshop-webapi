﻿using BookShop.Domain.Exciptions;

namespace BookShop.Domain.Exciptions.Users;

public class UserAlreadyExistsException : AlreadyExistsExcaption
{
	public UserAlreadyExistsException()
	{
		TitleMessage = "User already exists";
	}

	public UserAlreadyExistsException(string phone)
	{
		TitleMessage = "This phone is already registered";
	}
}
