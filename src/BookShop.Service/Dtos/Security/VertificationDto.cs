namespace BookShop.Service.Dtos.Security;

public class VertificationDto
{
    public int Code { get; set; }

    public int Attempt { get; set; }

    public DateTime CreatedAt { get; set; }
}

