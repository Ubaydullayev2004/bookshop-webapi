using System.Net;

namespace BookShop.Domain.Exciptions;

public class ExpiredException : Exception
{
    public HttpStatusCode StatusCode { get; } = HttpStatusCode.Gone;

    public string TitleMessage { get; protected set; } = String.Empty;
}
