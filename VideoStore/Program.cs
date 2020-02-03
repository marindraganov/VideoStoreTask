using System;

namespace VideoStore
{
    public static class Program
    {
        public static readonly Movie[] Movies = new[]
        {
            new Movie("Frozen (2013)", PriceCode.Kids),
            new Movie("The Notebook (2004)", PriceCode.Regular),
            new Movie("What Women Want (2000)", PriceCode.Regular),
            new Movie("Rambo: Last Blood (2019)", PriceCode.NewRelease),
            new Movie("Bad Boys for Life (2020)", PriceCode.NewRelease)
        };

        public static void Main()
        {
            var customer = new Customer("Peshko");
            customer.RentMovie(Movies[0], daysRented: 1);
            customer.RentMovie(Movies[1], daysRented: 2);
            customer.RentMovie(Movies[2], daysRented: 2);
            customer.RentMovie(Movies[3], daysRented: 4);
            customer.RentMovie(Movies[4], daysRented: 4);

            var statement = new CustomerStatement(customer);

            Console.WriteLine("Plain text statement:");
            Console.WriteLine(statement);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("HTML statement:");
            PrintHtmlStatement(customer);
            Console.ReadKey();
        }

        private static void PrintTextStatement(CustomerStatement statement)
        {
            statement.GenerateTextReport(new SimpleTextProcessors());
        }

        private static void PrintHtmlStatement(Customer customer)
        {
            // Your code here
        }
    }
}
