﻿using System.Collections.Generic;
using System.Linq;

namespace VideoStore
{
    public class Customer
    {
        private readonly IList<Rental> rentals;

        public Customer(string name)
        {
            this.Name = name;
            this.rentals = new List<Rental>();
        }

        public string Name { get; private set; }

        public void RentMovie(Movie movie, int daysRented)
        {
            this.rentals.Add(new Rental(movie, daysRented));
        }

        /// <summary>
        /// Generates a report about currently rented movies.
        /// </summary>
        public string Statement()
        {
            double totalAmount = 0;
            int frp = 0;
            var theItems = this.rentals.ToArray();
            // statement text will be appended here
            string report = $"{this.Name}'s Rental Record\n";
            for (int i = 0; i < theItems.Length; i++)
            {
                Rental each = theItems[i];
                double thisAmount = 0;
                //determine amounts for each line
                switch (each.Movie.PriceCode)
                {
                    case PriceCode.Regular:
                        thisAmount += 2;
                        if (each.DaysRented > 2)
                            thisAmount += (each.DaysRented - 2) * 1.5;
                        break;
                    case PriceCode.NewRelease:
                        thisAmount += each.DaysRented * 3;
                        break;
                    case PriceCode.Kids:
                        thisAmount += 1.5;
                        if (each.DaysRented > 3)
                            thisAmount += (each.DaysRented - 3) * 1.5;
                        break;
                }

                // add frequent renter points
                frp++;
                // add bonus for a two day new release rental
                if ((each.Movie.PriceCode == PriceCode.NewRelease) && each.DaysRented > 1) frp++;
                //show figures for this rental
                report += $"\t{each.Movie.Title}\t{thisAmount}\n";
                totalAmount += thisAmount;
            }

            //add footer lines
            report += $"Amount owed is {totalAmount}\n";
            report += $"{this.Name} has {frp} frequent renter points";
            return report;
        }
    }
}
