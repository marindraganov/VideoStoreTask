namespace VideoStore
{
    using System.Collections.Generic;
    using System.Linq;

    public class CustomerStatement
    {
        private readonly string customerName;
        private readonly IEnumerable<IRental> customerRentals;
        private readonly double totalAmount;
        private readonly double frequentRentPoints;

        public CustomerStatement(IStatementCustomer customer)
        {
            this.customerName = customer.Name;
            this.customerRentals = customer.Rentals.AsEnumerable();
            this.totalAmount = customer.Rentals.Sum(r => r.GetRentalAmount());
            this.frequentRentPoints = customer.Rentals.Sum(r => r.GetFrequentRentPoints());
        }

        public string GenerateTextReport()
        {
            string report = $"{this.customerName}'s Rental Record\n";
            foreach (var rental in this.customerRentals)
            {
                double thisAmount = rental.GetRentalAmount();

                //show figures for this rental
                report += $"\t{rental.GetItemTitle()}\t{thisAmount}\n";
            }

            //add footer lines
            report += $"Amount owed is {this.totalAmount}\n";
            report += $"{this.customerName} has {this.frequentRentPoints} frequent renter points";
            return report;
        }
    }
}
