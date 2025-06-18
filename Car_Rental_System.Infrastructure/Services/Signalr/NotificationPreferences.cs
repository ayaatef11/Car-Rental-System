namespace Car_Rental_System.Infrastructure.Services.Signalr
{
    public class NotificationPreferences
    {
        public string UserId { get; internal set; }
        public object NotifyMention { get; internal set; }
        public object NotifyShare { get; internal set; }
        public object NotifyRequest { get; internal set; }
        public object NotifyMessage { get; internal set; }
        public object NotifyAdds { get; internal set; }
        public object NotifySales { get; internal set; }
    }
}