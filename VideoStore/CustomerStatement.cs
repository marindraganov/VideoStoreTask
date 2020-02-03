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

        public string GenerateTextReport(ITextProcessor txtProcessor)
        {
            string report = txtProcessor.AddHeader($"{this.customerName}'s Rental Record");
            foreach (var rental in this.customerRentals)
            {
                var amount = rental.GetRentalAmount();
                var title = txtProcessor.AddTitle(rental.GetItemTitle());

                report += txtProcessor.AddLine($"{title}{amount}");
            }

            var footerContent = txtProcessor.AddLine($"Amount owed is {this.totalAmount}");
            footerContent += txtProcessor.Add($"{this.customerName} has {this.frequentRentPoints} frequent renter points");

            report += txtProcessor.AddFooter(footerContent);
            return report;
        }
    }
}
