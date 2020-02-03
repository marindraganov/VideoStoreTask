namespace VideoStore
{
    public class KidsRental : Rental
    {
        public KidsRental(Movie movie, int daysRented) : base(movie, daysRented)
        {
        }

        public override int GetFrequentRentPoints()
        {
            return 1;
        }
    }
}
