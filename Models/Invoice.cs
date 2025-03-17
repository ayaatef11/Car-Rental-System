namespace Car_Rental_System.Models
{

    public class Invoice : IComparable<Invoice>
    {
        public int Id { get; set; }
        public double RentalCharges { get; set; }
        public double Taxes { get; set; }
        public double TotalAmountDue { get; private set; }
        public RentalAgreement Agreement { get; set; }

        public Invoice()
        {
            Taxes = 0;
            RentalCharges = 0;
            TotalAmountDue = 0;
            Agreement = new RentalAgreement();
        }
        public Invoice(RentalAgreement agreement)
        {
            Agreement = agreement;
        }
        public void SetAgreement(RentalAgreement agreement)
        {
            Agreement = agreement;
        }

        public void ReadTaxes()
        {
            Console.Write("\nEnter Taxes: ");
            Taxes = double.Parse(Console.ReadLine()??string.Empty);
        }

        public double GetRentalCharges()
        {
            return RentalCharges;
        }

        public double CalculateTotalAmountDue()
        {
            TotalAmountDue = RentalCharges + Agreement.GetRentalPrice() + Taxes;
            return TotalAmountDue;
        }

        public override string ToString()
        {
            return $"{Agreement} | Rental Charges: {RentalCharges} | Taxes: {Taxes}";
        }
        public int CompareTo(Invoice other)
        {
            return CalculateTotalAmountDue().CompareTo(other.CalculateTotalAmountDue());
        }

        public static bool operator <(Invoice i1, Invoice i2) => i1.CompareTo(i2) < 0;
        public static bool operator >(Invoice i1, Invoice i2) => i1.CompareTo(i2) > 0;
        public static bool operator ==(Invoice i1, Invoice i2) => i1.CompareTo(i2) == 0;
        public static bool operator !=(Invoice i1, Invoice i2) => !(i1 == i2);

        public override bool Equals(object obj)
        {
            if (obj is Invoice invoice)
                return this == invoice;
            return false;
        }

        public override int GetHashCode() => CalculateTotalAmountDue().GetHashCode();
    }

}
