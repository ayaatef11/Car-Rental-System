namespace Car_Rental_System.Models
{
    public class Date : IComparable<Date>
    {
        public int Id { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public Date()
        {
            
        }
        public Date(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public void Read()
        {
            Console.Write("Enter date (day/month/year): ");
            string input = Console.ReadLine() ?? string.Empty; // Example: "16/03/2025"

            string[] parts = input.Split('/');
            if (parts.Length == 3)
            {
                Day = int.Parse(parts[0]);
                Month = int.Parse(parts[1]);
                Year = int.Parse(parts[2]);
            }
            else
            {
                Console.WriteLine("Invalid date format. Please use day/month/year.");
            }
        }

        public static int operator -(Date d1, Date d2)
        {
            DateTime date1 = new DateTime(d1.Year, d1.Month, d1.Day);
            DateTime date2 = new DateTime(d2.Year, d2.Month, d2.Day);
            return (int)(date1 - date2).TotalDays;
        }

        public static bool operator <(Date d1, Date d2) => d1.CompareTo(d2) < 0;
        public static bool operator >(Date d1, Date d2) => d1.CompareTo(d2) > 0;
        public static bool operator ==(Date d1, Date d2) => d1.CompareTo(d2) == 0;
        public static bool operator !=(Date d1, Date d2) => !(d1 == d2);
        public static bool operator <=(Date d1, Date d2) => d1.CompareTo(d2) <= 0;
        public static bool operator >=(Date d1, Date d2) => d1.CompareTo(d2) >= 0;

        public override bool Equals(object obj)
        {
            if (obj is Date d)
                return this == d;
            return false;
        }

        public override int GetHashCode() => (Year, Month, Day).GetHashCode();

        public int CompareTo(Date other)
        {
            DateTime thisDate = new DateTime(Year, Month, Day);
            DateTime otherDate = new DateTime(other.Year, other.Month, other.Day);
            return thisDate.CompareTo(otherDate);
        }

        public override string ToString()
        {
            return $"{Day}/{Month}/{Year}";
        }

        public static bool Overlap(Date start1, Date end1, Date start2, Date end2)
        {
            return start2 <= end1;
        }

       

    }

}
