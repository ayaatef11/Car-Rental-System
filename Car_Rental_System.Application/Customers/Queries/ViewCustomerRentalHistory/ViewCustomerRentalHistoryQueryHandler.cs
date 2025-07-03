namespace Car_Rental_System.Application.Customers.Queries.ViewCustomerRentalHistory;
    internal class ViewCustomerRentalHistoryQueryHandler(IUnitOfWork _uow):IRequestHandler<ViewCustomerRentalHistoryQuery, ViewCustomerRentalHistoryResult?>
    {

    public async Task<ViewCustomerRentalHistoryResult?> Handle(ViewCustomerRentalHistoryQuery request, CancellationToken cancellationToken)
    {
        var customer = await _uow.Repository<Customer>().GetByIdAsync(request.CustomerId);

        if (customer == null)
            return null;

        var result = new ViewCustomerRentalHistoryResult
        {
            CustomerId = customer.Id,
            CustomerName = customer.FullName,
            //RentalHistory = customer.Reservations.Rentals.Select(r => new RentalRecordDto
            //{
            //    RentalId = r.Id,
            //    RentedOn = r.RentedOn,
            //    ReturnedOn = r.ReturnedOn,
            //    CarModel = r.Car.Model
            //}).ToList()
        };

        return result;
    }
    }



