namespace Car_Rental_System.Application.Reservations.Queries.GetRentalCharge;
public class GetRentalChargeQuery : IRequest<double?>
{
    public int InvoiceId { get; }

    public GetRentalChargeQuery(int invoiceId)
    {
        InvoiceId = invoiceId;
    }
}

