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
    }
}
