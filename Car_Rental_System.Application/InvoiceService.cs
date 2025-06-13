using Car_Rental_System.Models;

namespace Car_Rental_System.Services
{
    public class InvoiceService(Invoice Invoice)
    {
        public void SetAgreement(Reservation agreement)
        {
            Invoice.Reservation = agreement;
        }

        public void ReadTaxes()
        {
            Console.Write("\nEnter Taxes: ");
            Invoice.Taxes = double.Parse(Console.ReadLine() ?? string.Empty);
        }

        public double GetRentalCharges()
        {
            return Invoice.RentalCharges;
        }

    }
}
