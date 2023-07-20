namespace BookShop.Domain.Entities.BookDiscounts;

public class BookDiscount:Auditable
{
    public long BookId { get; set; }

    public long DiscountId { get; set; }

    public string Description { get; set; } = String.Empty;

    public int Persentage { get; set; }

    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
}

