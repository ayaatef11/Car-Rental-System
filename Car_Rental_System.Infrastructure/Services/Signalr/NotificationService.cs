using Car_Rental_System.Infrastructure.Parameters;
using Car_Rental_System.Infrastructure.Persistence;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental_System.Infrastructure.Services.Signalr;

public class NotificationService(AppDbContext _context, IHubContext<SignalServer> _hubContext) : INotificationService
{
    public async Task<List<Notification>> GetAllNotifications(int nToUserId, bool bIsGetOnlyUnread)
    {
        var notificationsQuery = _context.Notifications.AsQueryable();
        if (bIsGetOnlyUnread)
        {
            notificationsQuery = notificationsQuery.Where(n => !n.IsRead);
        }

        return await notificationsQuery.ToListAsync();
    }
    public async Task<bool> SendNotificationToUserAsync(string userId, string message)
    {
        try
        {
            var notification = new Notification
            {
                Message = message,
                IsRead = false,
                CreatedDate = DateTime.UtcNow
            };

            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();

            await _hubContext.Clients.User(userId).SendAsync("displayNotification");

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    public NotificationPreferences GetUserNotificationPreferences(string userId)
    {
        return _context.NotificationPreferences.FirstOrDefault(np => np.UserId == userId);
    }

    public void UpdateNotificationPreferences(string userId, NotificationPreferencesParameters preferences)
    {
        var existingPreferences = _context.NotificationPreferences
                                           .FirstOrDefault(np => np.UserId == userId);

        if (existingPreferences != null)
        {
            existingPreferences.NotifyMention = preferences.NotifyMention;
            existingPreferences.NotifyRequest = preferences.NotifyRequest;
            existingPreferences.NotifyShare = preferences.NotifyShare;
            existingPreferences.NotifyMessage = preferences.NotifyMessage;
            existingPreferences.NotifyAdds = preferences.NotifyAdds;
            existingPreferences.NotifySales = preferences.NotifySales;

            _context.SaveChanges();
        }
        else
        {
            var newPreferences = new NotificationPreferences
            {
                UserId = userId,
                NotifyMention = preferences.NotifyMention,
                NotifyRequest = preferences.NotifyRequest,
                NotifyShare = preferences.NotifyShare,
                NotifyMessage = preferences.NotifyMessage,
                NotifyAdds = preferences.NotifyAdds,
                NotifySales = preferences.NotifySales
            };
            _context.NotificationPreferences.Add(newPreferences);
            _context.SaveChanges();
        }

    }
}



