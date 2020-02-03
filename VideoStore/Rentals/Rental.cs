namespace VideoStore
{
    public class Rental : IRental
    {
        readonly Movie movie;
        readonly int daysRented;

        public Rental(Movie movie, int daysRented)
        {
            this.movie = movie;
            this.daysRented = daysRented;
        }

        public string GetItemTitle()
        {
            return this.movie.Title;
        }

        public int GetFrequentRentPoints()
        {
            var points = 1;

            if ((this.movie.PriceCode == PriceCode.NewRelease) && this.daysRented > 1) points++;

            return points;
        }

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
