namespace VideoStore
{
    public class RegularRental : Rental
    {
        public RegularRental(Movie movie, int daysRented) : base(movie, daysRented)
        {
        }

        public override int GetFrequentRentPoints()
        {
            return 1;
        }
    }
}
