namespace VideoStore
{
    public class Movie
    {
        /// <summary>
        /// This is the movie constructor.
        /// </summary>
        public Movie(string title, PriceCode priceCode)
        {
            this.Title = title;
            this.PriceCode = priceCode;
        }

        public string Title { get; private set; }

        public PriceCode PriceCode { get; private set; }
    }
}
