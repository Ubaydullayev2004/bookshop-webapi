namespace BookShop.Domain.Entities.Categories;

public class Categoriy:Auditable
{
    public string Name { get; set; } = String.Empty;

    public string Description { get; set; } = String.Empty;

    public string ImagePath { get; set; } = String.Empty;
}
