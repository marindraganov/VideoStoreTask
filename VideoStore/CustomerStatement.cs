namespace VideoStore
{
    using System.Linq;

    public class CustomerStatement
    {
        public static string GenerateTextReport(Customer customer)
        {
            double totalAmount = 0;

            // statement text will be appended here
            string report = $"{customer.Name}'s Rental Record\n";
            foreach (var rental in customer.Rentals)
            {
                double thisAmount = rental.GetRentalAmount();

                //show figures for this rental
                report += $"\t{rental.Movie.Title}\t{thisAmount}\n";
                totalAmount += thisAmount;
            }

            //add footer lines
            report += $"Amount owed is {totalAmount}\n";

            var frequentRentPoints = customer.Rentals.Sum(r => r.GetFrequentRentPoints());
            report += $"{customer.Name} has {frequentRentPoints} frequent renter points";
            return report;
        }
    }
}
