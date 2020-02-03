using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using VideoStore;

namespace Tests_VideoStore
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCustomerTextStatementGeneration()
        {
            var customer = new Customer("Peshko");

            var movies = Program.Movies;
            customer.RentMovie(movies[0], daysRented: 1);
            customer.RentMovie(movies[1], daysRented: 2);
            customer.RentMovie(movies[2], daysRented: 2);
            customer.RentMovie(movies[3], daysRented: 4);
            customer.RentMovie(movies[4], daysRented: 4);

            //var txt = Regex.Escape(customer.Statement());
            Assert.AreEqual("Peshko's\\ Rental\\ Record\\n\\tFrozen\\ \\(2013\\)\\t1\\.5\\n\\tThe\\ Notebook\\ \\(2004\\)\\t2\\n\\tWhat\\ Women\\ Want\\ \\(2000\\)\\t2\\n\\tRambo:\\ Last\\ Blood\\ \\(2019\\)\\t12\\n\\tBad\\ Boys\\ for\\ Life\\ \\(2020\\)\\t12\\nAmount\\ owed\\ is\\ 29\\.5\\nPeshko\\ has\\ 7\\ frequent\\ renter\\ points", 
                Regex.Escape(CustomerStatement.GenerateTextReport(customer)));
        }
    }
}