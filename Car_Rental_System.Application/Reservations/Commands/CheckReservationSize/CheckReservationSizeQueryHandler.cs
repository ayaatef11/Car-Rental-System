namespace Car_Rental_System.Application.Reservations.Commands.CheckReservationSize;
internal class CheckReservationSizeQueryHandler : IRequestHandler<CheckReservationSizeQuery, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private const int MaxReservationLimit = 5;

    public CheckReservationSizeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(CheckReservationSizeQuery request, CancellationToken cancellationToken)
    {
        var customer = await _unitOfWork.Repository<Car>().GetByIdAsync(request.CustomerId);//WithReservations

        if (customer == null || customer.Reservations == null)
            return false;

        return customer.Reservations.Count <= MaxReservationLimit;
    }
}


