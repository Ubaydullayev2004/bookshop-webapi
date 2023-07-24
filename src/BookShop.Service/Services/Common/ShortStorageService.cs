using BookShop.Service.Interfaces.Common;

namespace BookShop.Service.Services.Common;

public class ShortStorageService : IShortStorgeService
{
    public IDictionary<string, string> KeyValuePairs { get; set; }
    public ShortStorageService()
    {
        KeyValuePairs = new Dictionary<string, string>();
    }
}
