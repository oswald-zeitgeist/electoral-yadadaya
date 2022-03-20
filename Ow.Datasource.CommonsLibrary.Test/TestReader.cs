using System.Linq;
using NUnit.Framework;
using Ow.DataSource.CommonsLibrary;

namespace Ow.Datasource.CommonsLibrary.Test
{
    public class Tests
    {
        private CommonsLibraryCsvReader reader;
        
        [SetUp]
        public void Setup()
        {
            reader = new CommonsLibraryCsvReader("1918_2019election_results.csv");
        }

        [Test]
        public void TestBasicCounts()
        {
            var results = reader.Read();
            Assert.That(results.Count(), Is.EqualTo(28));
            var proxyForRowsInSource = results.SelectMany(x => x.Seats).SelectMany(x => x.VoteCount.Piles);
            Assert.That(proxyForRowsInSource.Count(), Is.EqualTo(53418));
        }
    }
}