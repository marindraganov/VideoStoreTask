using System;

namespace VideoStore
{
    public class Rental
    {
        public Rental(Movie movie, int daysRented)
        {
            this.Movie = movie;
            this.DaysRented = daysRented;
        }

        public Movie Movie { get; private set; }

        public int DaysRented { get; private set; }

        public int GetFrequentRentPoints()
        {
            var points = 1;

            if ((this.Movie.PriceCode == PriceCode.NewRelease) && this.DaysRented > 1) points++;

            return points;
        }

        public double GetRentalAmount()
        {
            double thisAmount = 0;
            switch (this.Movie.PriceCode)
            {
                case PriceCode.Regular:
                    thisAmount += 2;
                    if (this.DaysRented > 2)
                        thisAmount += (this.DaysRented - 2) * 1.5;
                    break;
                case PriceCode.NewRelease:
                    thisAmount += this.DaysRented * 3;
                    break;
                case PriceCode.Kids:
                    thisAmount += 1.5;
                    if (this.DaysRented > 3)
                        thisAmount += (this.DaysRented - 3) * 1.5;
                    break;
            }

            return thisAmount;
        }
    }
}
