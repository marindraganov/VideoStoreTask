﻿namespace VideoStore
{
    public class NewReleaseRental : Rental
    {
        public NewReleaseRental(Movie movie, int daysRented) : base(movie, daysRented)
        {
        }

        public override int GetFrequentRentPoints()
        {
            var points = this.daysRented > 1 ? 2 : 1;

            return points;
        }

        public override double GetRentalAmount()
        {
            double amount = this.daysRented * 3; ;

            return amount;
        }
    }
}
