using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.DataGenerator
{
    public class Hobbies
    {
        private static List<string> HobbyList { get
            {
                return new List<string>()
                {
                    "fishing",
                    "cooking",
                    "tennis",
                    "golfing",
                    "rock climbing",
                    "drawing",
                    "gardening",
                    "sports",
                    "exercising",
                    "photography",
                    "writing",
                    "volunteering",
                    "movies",
                    "stamp collecting",
                    "rock collecting",
                    "blogging",
                    "ceramics",
                    "home improvement",
                    "community improvement",
                    "home brewing",
                    "puzzles"
                };
            } 
        }

        public static Dictionary<int,string> HobbyLookup { get
            {
                var counter = 0;
                return HobbyList.ToDictionary(k => ++counter, v => v);
            } 
        }
    }
}
