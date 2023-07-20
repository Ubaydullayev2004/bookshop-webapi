namespace BookShop.Domain.Exciptions.Category;

public class CategoryNotFoundException :NotFoundException
{
    public CategoryNotFoundException()
    {
        this.TitleMessage = "Category not found!";
    }
}
