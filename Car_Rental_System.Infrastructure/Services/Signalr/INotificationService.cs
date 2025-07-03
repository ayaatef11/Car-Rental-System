namespace Car_Rental_System.Infrastructure.Services.Signalr;
public interface INotificationService
{
    Task<List<Notification>> GetAllNotifications(int nToUserId, bool getOnlyUnRead);
    Task<bool> SendNotificationToUserAsync(string userId, string message);
    NotificationPreferences GetUserNotificationPreferences(string userId);
    void UpdateNotificationPreferences(string userId, NotificationPreferencesParameters preferences);

}
