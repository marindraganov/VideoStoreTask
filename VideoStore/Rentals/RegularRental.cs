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

        public override double GetRentalAmount()
        {
            double amount = 2;

            if (this.daysRented > 2)
            {
                amount += (this.daysRented - 2) * 1.5;
            }

            return amount;
        }
    }
}
