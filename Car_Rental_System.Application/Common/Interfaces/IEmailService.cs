using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_System.Application.Common.Interfaces
;
public interface IEmailService
{
    Task SendEmailAsync(string to, string subject, string body);
}