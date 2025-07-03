namespace Car_Rental_System.Infrastructure.Services.EmailService;

internal class EmailService(IFluentEmail fluentEmail) : IEmailService
{
    public async Task SendEmailAsync(string email, string subject, string body)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email address must not be null or empty.", nameof(email));

        await fluentEmail
            .To(email)
            .Subject(subject)
            .Body(body, isHtml: true)
            .SendAsync();

    }

}
