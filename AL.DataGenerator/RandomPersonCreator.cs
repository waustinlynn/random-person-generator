using AL.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.DataGenerator
{
    public class RandomPersonCreator
    {
        private readonly Dictionary<int, string> _namesLookup;
        private readonly Dictionary<int, string> _citiesLookup;
        private readonly Dictionary<int, string> _hobbyLookup;
        private readonly Random _random;
        public RandomPersonCreator()
        {
            _namesLookup = Names.NamesLookup;
            _citiesLookup = Cities.CityLookup;
            _hobbyLookup = Hobbies.HobbyLookup;
            _random = new Random();
        }
        public Person CreateRandomPerson()
        {
            var hobbyCount = _random.Next(1, 5);
            var hobbyList = new HashSet<string>();
            for(var i = 0; i < hobbyCount; i++)
            {
                var hobby = _hobbyLookup[_random.Next(1, _hobbyLookup.Count)];
                if (hobbyList.Contains(hobby)) continue;
                hobbyList.Add(hobby);
            }
            return new Person()
            {
                FirstName = _namesLookup[_random.Next(1, _namesLookup.Count)],
                LastName = _namesLookup[_random.Next(1, _namesLookup.Count)],
                City = _citiesLookup[_random.Next(1, _namesLookup.Count)],
                Hobbies = String.Join(" ", hobbyList)
            };
        }
    }
}
