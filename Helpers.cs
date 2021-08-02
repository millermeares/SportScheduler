using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportScheduleConsole
{
    public static class Helpers
    {
        public static IEnumerable<T> Shuffle<T>(this IList<T> list)
        {
            Random rand = new Random();
            return list.OrderBy<T, int>((item) => rand.Next());
        }
    }
}
