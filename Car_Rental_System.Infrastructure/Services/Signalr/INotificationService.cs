using Car_Rental_System.Infrastructure.Parameters;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_System.Infrastructure.Services.Signalr;
public interface INotificationService
{
    Task<List<Notification>> GetAllNotifications(int nToUserId, bool getOnlyUnRead);
    Task<bool> SendNotificationToUserAsync(string userId, string message);
    NotificationPreferences GetUserNotificationPreferences(string userId);
    void UpdateNotificationPreferences(string userId, NotificationPreferencesParameters preferences);

}
