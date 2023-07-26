namespace BookShop.Domain.Exciptions.Books;

public class BookNotFoundException:Exception
{
    private string TitleMessage;

    public BookNotFoundException()
    {
        this.TitleMessage = "Book not found!";
    }
}

