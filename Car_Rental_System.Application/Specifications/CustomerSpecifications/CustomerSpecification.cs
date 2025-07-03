using Car_Rental_System.Infrastructure.Specifications;

namespace Car_Rental_System.Application.Specifications.CustomerSpecifications;
    public class CustomerSpecification : BaseSpecification<Customer>
    {
        public CustomerSpecification()
        {
            IncludesCriteria.Add(P => P.Reservations!);
        }
        public CustomerSpecification(int id)
        {
            WhereCriteria = P => P.Id == id;

            IncludesCriteria.Add(P => P.Reservations!);
        }
        public CustomerSpecification(CustomerSpecificationParams param)
        {
            WhereCriteria = P => P.Id == param.Id;

            IncludesCriteria.Add(P => P.Reservations!);
        }
    }
