using AL.DataGenerator;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AL.Tests
{
    public class Tests
    {
        private Dictionary<int, string> _firstNames;
        private Dictionary<int, string> _lastNames;
        private Dictionary<int, string> _cities;
        private RandomPersonCreator _randomPersonCreator;
        [SetUp]
        public void Setup()
        {
            _firstNames = Names.NamesLookup;
            _lastNames = Names.NamesLookup;
            _cities = Cities.CityLookup;
            _randomPersonCreator = new RandomPersonCreator();
        }

        [Test]
        public void CheckFirstNames()
        {
            Assert.IsTrue(_firstNames.Count > 0);
        }

        [Test]
        public void CheckLastNames()
        {
            Assert.IsTrue(_firstNames.Count > 0);
        }

        [Test]
        public void CheckSpecificName()
        {
            Assert.AreEqual("Khalil Zander", $"{_firstNames[1]} {_lastNames[5]}");
        }

        [Test]
        public void CheckCityNames()
        {
            Assert.IsTrue(_cities.Count > 0);
        }

        [Test]
        public void ValidRandomNames()
        {
            for (var i = 0; i < 100000; i++)
            {
                //for any number, we should be able to get a person without throwing an exception
                var person = _randomPersonCreator.CreateRandomPerson();
                Assert.IsTrue(!String.IsNullOrEmpty(person.FirstName));
                Assert.IsTrue(!String.IsNullOrEmpty(person.LastName));
                Assert.IsTrue(!String.IsNullOrEmpty(person.City));
            }
            Assert.Pass();
        }

        [Test]
        public void CanWriteRecords()
        {
            var bigFileCreator = new BigFileCreator();
            bigFileCreator.CreateBigFile("C:\\Users\\waust\\source\\repos\\python-search-code\\largenameslist.json", 1000000, false);
        }
    }
}