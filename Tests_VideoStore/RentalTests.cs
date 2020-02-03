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
        [Test]
        public void TestGetFrequentRentPointsDouble()
        {
            var newReleaseMovie = new Movie("Test", PriceCode.NewRelease);
            var rental = new Rental(newReleaseMovie, 2);

            Assert.AreEqual(2, rental.GetFrequentRentPoints());
        }

        [Test]
        public void TestGetFrequentRentPointsSinglePointNoNewRelease()
        {
            var oldMoive = new Movie("Test", PriceCode.Regular);
            var rental = new Rental(oldMoive, 10);

            Assert.AreEqual(1, rental.GetFrequentRentPoints());
        }
    }
}
