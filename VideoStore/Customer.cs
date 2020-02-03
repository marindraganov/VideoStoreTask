using System.Collections.Generic;
using System.Linq;

namespace VideoStore
{
    public class Customer
    {
        private readonly List<Rental> rentals;

        public Customer(string name)
        {
            this.Name = name;
            this.rentals = new List<Rental>();
        }

        public string Name { get; private set; }

        public IReadOnlyList<Rental> Rentals 
        { 
            get 
            { 
                return this.rentals.AsReadOnly(); 
            } 
        }

        public void RentMovie(Movie movie, int daysRented)
        {
            this.rentals.Add(new Rental(movie, daysRented));
        }
    }
}
