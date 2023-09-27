using Eleshop.Persistance.Dtos.Notifications;

namespace Eleshop.Services.Interfaces.Notifications;

public interface ISmsSender
{
    public Task<bool> SendAsync(SmsMessage smsMessage);
}
