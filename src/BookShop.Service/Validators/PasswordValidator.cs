
namespace BookShop.Service.Validators;

public class PasswordValidator
{
    public static string Symbols { get; } = "~`!@#$%^&*()_-+={[}]|\\:;\"'<,>.?/";

    public static (bool IsValid, string Message) IsStrongPassword(string password)
    {
        if (password.Length < 8) return (IsValid: false, Message: "Password can not be less than 8 characters!");

        bool isNumberExists = false;
        bool isCharacterExists = false;

        foreach (var item in password)
        {
            if (char.IsDigit(item)) isNumberExists = true;
            if (Symbols.Contains(item)) isCharacterExists = true;
        }

        if (isNumberExists == false) return (IsValid: false, Message: "Password should contain at least one Digit!");
        if (isCharacterExists == false) return (IsValid: false, Message: "Password should contain at least one Symbol like (#@$%.!)!");

        return (IsValid: true, "");
    }
}
