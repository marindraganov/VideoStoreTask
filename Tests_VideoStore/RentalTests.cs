using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using VideoStore;

namespace Tests_VideoStore
{
    [TestFixture]
    public class RentalTests
    {
        Movie regularMovie = new Movie("Regular", PriceCode.Regular);
        Movie newMovie = new Movie("NewMovie", PriceCode.NewRelease);
        Movie kidsMovie = new Movie("KidsMovie", PriceCode.Kids);

        [Test]
        public void TestGetFrequentRentPointsDouble()
        {
            var rental = Rental.Create(newMovie, 2);

            Assert.AreEqual(2, rental.GetFrequentRentPoints());
        }

        [Test]
        public void TestGetFrequentRentPointsSinglePointNoNewRelease()
        {
            var rental = Rental.Create(regularMovie, 10);

            Assert.AreEqual(1, rental.GetFrequentRentPoints());
        }

        [Test]
        public void TestGetFrequentRentPointsSinglePointKids()
        {
            var rental = Rental.Create(kidsMovie, 10);

            Assert.AreEqual(1, rental.GetFrequentRentPoints());
        }

        [Test]
        public void TestGetRentalAmountRegular()
        {
            var rental = Rental.Create(regularMovie, 2);

            Assert.AreEqual(2.0, rental.GetRentalAmount());
        }

        [Test]
        public void TestGetRentalAmountRegularMoreThan2Days()
        {
            var rental = Rental.Create(regularMovie, 3);

            Assert.AreEqual(3.5, rental.GetRentalAmount());
        }

        [Test]
        public void TestGetRentalAmountNewRelease()
        {
            var rental = Rental.Create(newMovie, 3);

            Assert.AreEqual(9.0, rental.GetRentalAmount());
        }
    }
}
