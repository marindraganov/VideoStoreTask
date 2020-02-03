namespace VideoStore
{
    using System;

    public abstract class Rental : IRental
    {
        readonly Movie movie;
        protected readonly int daysRented;

        internal Rental(Movie movie, int daysRented)
        {
            this.movie = movie;
            this.daysRented = daysRented;
        }

        //This one can be extracted in separate factory class
        public static Rental Create(Movie movie, int daysRented)
        {
            switch (movie.PriceCode)
            {
                case PriceCode.Kids:
                    return new KidsRental(movie, daysRented);
                case PriceCode.Regular:
                    return new RegularRental(movie, daysRented);
                case PriceCode.NewRelease:
                    return new NewReleaseRental(movie, daysRented);
                default:
                    throw new ArgumentOutOfRangeException($"We don't have rental supporting for {movie.PriceCode}!");
            }
        }

        public string GetItemTitle()
        {
            return this.movie.Title;
        }

        public abstract int GetFrequentRentPoints();

        public double GetRentalAmount()
        {
            double thisAmount = 0;
            switch (this.movie.PriceCode)
            {
                case PriceCode.Regular:
                    thisAmount += 2;
                    if (this.daysRented > 2)
                        thisAmount += (this.daysRented - 2) * 1.5;
                    break;
                case PriceCode.NewRelease:
                    thisAmount += this.daysRented * 3;
                    break;
                case PriceCode.Kids:
                    thisAmount += 1.5;
                    if (this.daysRented > 3)
                        thisAmount += (this.daysRented - 3) * 1.5;
                    break;
            }

            return thisAmount;
        }
    }
}
