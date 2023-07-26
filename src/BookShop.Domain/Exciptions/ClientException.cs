using System.Net;

namespace BookShop.Domain.Exciptions;

public abstract class ClientException : Exception
{
    public abstract HttpStatusCode StatusCode { get; }

    public abstract string TitleMessage { get; protected set; }
}
