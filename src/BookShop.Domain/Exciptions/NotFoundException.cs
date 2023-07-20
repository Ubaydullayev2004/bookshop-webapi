using System.Net;

namespace BookShop.Domain.Exciptions;

public class NotFoundException:Exception
{
    public HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;

    public string TitleMessage { get; protected set; } = String.Empty;

}
