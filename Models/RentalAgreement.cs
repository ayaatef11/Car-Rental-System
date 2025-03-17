namespace Car_Rental_System.Models
{
    public class RentalAgreement : IComparable<RentalAgreement>
    {
        public int Id { get; set; }
        public int RentalPeriod { get; set; }
        public double RentalRate { get; set; }
        public double RentalPrice { get; private set; }
        public double InsuranceCharges { get; set; }
        public Car Car { get; set; }
        public Reservation Reservation { get; set; }
        public RentalAgreement()
        {
            RentalPeriod = 0;
            RentalPrice = 0;
            Car = null;
            Reservation = null;
        }
        public double GetRentalPrice()
        {
            RentalPrice = RentalPeriod * RentalRate + InsuranceCharges;
            return RentalPrice;
        }

        public static double operator +(RentalAgreement agreement, int price)
        {
            return price + agreement.GetRentalPrice();
        }
        public int CompareTo(RentalAgreement other)
        {
            return GetRentalPrice().CompareTo(other.GetRentalPrice());
        }
        public static bool operator <(RentalAgreement r1, RentalAgreement r2) => r1.CompareTo(r2) < 0;
        public static bool operator >(RentalAgreement r1, RentalAgreement r2) => r1.CompareTo(r2) > 0;
        public static bool operator ==(RentalAgreement r1, RentalAgreement r2) => r1.CompareTo(r2) == 0;
        public static bool operator !=(RentalAgreement r1, RentalAgreement r2) => !(r1 == r2);

        public override bool Equals(object obj)
        {
            if (obj is RentalAgreement agreement)
                return this == agreement;
            return false;
        }

        public override int GetHashCode() => GetRentalPrice().GetHashCode();
        public void ReadData()
        {
            Console.Write("Enter Rental Period: ");
            RentalPeriod = int.Parse(Console.ReadLine());
            Console.Write("Enter Rental Rate: ");
            RentalRate = double.Parse(Console.ReadLine());
            Console.Write("Enter Insurance Charges: ");
            InsuranceCharges = double.Parse(Console.ReadLine());
        }
        public override string ToString()
        {
            return $"\nRental Period: {RentalPeriod} | Rental Price: {GetRentalPrice()} " +
                   $"| Insurance Charges: {InsuranceCharges} | Rental Rate: {RentalRate}";
        }
    }

}
