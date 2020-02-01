using System;

namespace VideoStore
{
    internal static class Program
    {
        private static readonly Movie[] Movies = new[]
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
            customer.AddRental(new Rental(Movies[0], daysRented: 1));
            customer.AddRental(new Rental(Movies[1], daysRented: 2));
            customer.AddRental(new Rental(Movies[2], daysRented: 2));
            customer.AddRental(new Rental(Movies[3], daysRented: 4));
            customer.AddRental(new Rental(Movies[4], daysRented: 4));

            Console.WriteLine("Plain text statement:");
            PrintTextStatement(customer);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("HTML statement:");
            PrintHtmlStatement(customer);
            Console.ReadKey();
        }

        private static void PrintTextStatement(Customer customer)
        {
            Console.WriteLine(customer.Statement());
        }

        private static void PrintHtmlStatement(Customer customer)
        {
            // Your code here
        }
    }
}
