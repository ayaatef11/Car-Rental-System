namespace Car_Rental_System.Infrastructure.Parameters;
public class NotificationPreferencesParameters
{
    public string NotifyMention { get; set; } = null!;
    public string NotifyRequest { get; set; } = null!;
    public string NotifyShare { get; set; } = null!;
    public string NotifyMessage { get; set; } = null!;
    public string NotifyAdds { get; set; } = null!;
    public string NotifySales { get; set; } = null!;
}