namespace Car_Rental_System.Application.Reservations.Queries.GetRentalCharge;
internal class GetRentalChargeQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetRentalChargeQuery, double?>
{
    public async Task<double?> Handle(GetRentalChargeQuery request, CancellationToken cancellationToken)
    {
        var invoice = await _unitOfWork.Repository<Invoice>().GetByIdAsync(request.InvoiceId);
        return invoice?.RentalCharges;
    }
}

