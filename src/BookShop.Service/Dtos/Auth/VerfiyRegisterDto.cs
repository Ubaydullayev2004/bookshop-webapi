namespace BookShop.Service.Dtos.Auth;

public class VerfiyRegisterDto
{
    public string PhoneNumber { get; set; } = String.Empty;

    public int Code { get; set; }
}
