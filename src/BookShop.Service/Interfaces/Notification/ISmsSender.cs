using BookShop.Service.Dtos.Notification;

namespace BookShop.Service.Interfaces.Notification;

public interface ISmsSender
{
    public Task<bool> SendAsync(SmsMessage smsMessage);

}
