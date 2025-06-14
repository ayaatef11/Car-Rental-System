using Car_Rental_System.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_System.Application.Cars.Queries.GetAvailableCars;
    internal class GetAvailableCarsQuery
    {
    
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public GetAvailableCarsQuery(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
    }



