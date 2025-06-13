using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_System.Infrastructure.Persistence.Seeders
;
internal interface ISeeder
{
    Task SeedAsync();
}
