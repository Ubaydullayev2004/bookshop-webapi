using System.Net;

namespace BookShop.Domain.Exciptions;

public class VerificationTooManyRequestsException
{
    public HttpStatusCode StatusCode { get; } = HttpStatusCode.TooManyRequests;

    public string TitleMessage { get; protected set; } = String.Empty;
}

