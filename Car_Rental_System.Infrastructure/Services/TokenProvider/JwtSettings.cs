using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_System.Infrastructure.Services.TokenProvider
;
internal class JwtSettings
{
    public const string Section = "JwtSettings";
    public string Secret { get; set; } = default!;
    public int TokenExpirationInMinutes { get; set; }
    public string Issuer { get; set; } = default!;
    public string Audience { get; set; } = default!;

}
