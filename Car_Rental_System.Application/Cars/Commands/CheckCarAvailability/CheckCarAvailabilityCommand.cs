using Car_Rental_System.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_System.Application.Cars.Commands.CheckCarAvailability;
public class CheckCarAvailabilityCommand
{
    public int CarId { get; set; }
    public Date StartDate { get; set; }
    public Date EndDate { get; set; }
}