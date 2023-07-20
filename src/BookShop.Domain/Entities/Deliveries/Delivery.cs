using System.ComponentModel.DataAnnotations;

namespace BookShop.Domain.Entities.Deliveries;

public class Delivery : Auditable
{
    [MaxLength(13)]
    public string PhoneNumber { get; set; } = String.Empty;

    public bool PhoneNumberConfirmed { get; set; }

    public string PasswordHash { get; set; } = String.Empty;

    public string Salt { get; set; } = String.Empty;
}
