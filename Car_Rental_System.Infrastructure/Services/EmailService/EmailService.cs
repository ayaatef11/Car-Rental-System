using Car_Rental_System.Application.Common.Interfaces;
using FluentEmail.Core;

namespace Car_Rental_System.Infrastructure.Services.EmailService;

internal class EmailService(IFluentEmail fluentEmail) : IEmailService
{
    public async Task SendEmailAsync(string email, string subject, string body)
    {
        await fluentEmail
            .To(email)
            .Subject(subject)
            .Body(body, isHtml: true)
            .SendAsync();

    }

}
