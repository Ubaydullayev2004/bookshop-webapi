using System.Net;

namespace BookShop.Domain.Exciptions;

public class AlreadyExistsExcaption : Exception
{
    public HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;

    public string TitleMessage { get; protected set; } = String.Empty;
}
