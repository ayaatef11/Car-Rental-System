using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_System.Infrastructure.Services.EmailService
;
using FluentEmail.Core;

namespace BookManagement.Infrastructure.Services.EmailService;
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
