
namespace Car_Rental_System.Infrastructure.Services.Signalr
{
    internal class Notification
    {
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}