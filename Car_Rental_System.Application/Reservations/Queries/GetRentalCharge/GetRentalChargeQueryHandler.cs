using Car_Rental_System.Domain.Entities;
using Car_Rental_System.Infrastructure.Repositories;
using MediatR;

namespace Car_Rental_System.Application.Reservations.Queries.GetRentalCharge;
internal class GetRentalChargeQueryHandler : IRequestHandler<GetRentalChargeQuery, double?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetRentalChargeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<double?> Handle(GetRentalChargeQuery request, CancellationToken cancellationToken)
    {
        var invoice = await _unitOfWork.Repository<Invoice>().GetByIdAsync(request.InvoiceId);
        return invoice?.RentalCharges;
    }
}

