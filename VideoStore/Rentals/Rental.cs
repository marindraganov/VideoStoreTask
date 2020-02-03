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

        public abstract double GetRentalAmount();
    }
}
