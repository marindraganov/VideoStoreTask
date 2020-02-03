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

        public override double GetRentalAmount()
        {
            var amount = 1.5;
            if (this.daysRented > 3)
                amount += (this.daysRented - 3) * 1.5;

            return amount;
        }
    }
}
