namespace Car_Rental_System.Application.Common.Interfaces;
public interface IEmailService
{
    Task SendEmailAsync(string to, string subject, string body);
}