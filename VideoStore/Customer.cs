using System.Collections.Generic;
using System.Linq;

namespace VideoStore
{
    public class Customer
    {
        private readonly IList<Rental> rentals;

        public Customer(string name)
        {
            this.Name = name;
            this.rentals = new List<Rental>();
        }

        public string Name { get; private set; }

        public void RentMovie(Movie movie, int daysRented)
        {
            this.rentals.Add(new Rental(movie, daysRented));
        }

        /// <summary>
        /// Generates a report about currently rented movies.
        /// </summary>
        public string Statement()
        {
            double totalAmount = 0;

            // statement text will be appended here
            string report = $"{this.Name}'s Rental Record\n";
            foreach (var rental in this.rentals)
            {
                double thisAmount = rental.GetRentalAmount();

                //show figures for this rental
                report += $"\t{rental.Movie.Title}\t{thisAmount}\n";
                totalAmount += thisAmount;
            }

            //add footer lines
            report += $"Amount owed is {totalAmount}\n";

            var frequentRentPoints = this.rentals.Sum(r => r.GetFrequentRentPoints());
            report += $"{this.Name} has {frequentRentPoints} frequent renter points";
            return report;
        }
    }
}
