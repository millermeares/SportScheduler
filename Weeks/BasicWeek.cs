using System;
using System.Collections.Generic;
using System.Text;

namespace SportScheduleConsole
{
    public class BasicWeek : IWeek
    {
        public int WeekNum { get; set; }
        public List<IGame> Games { get; set; } = new List<IGame>();
        public BasicWeek()
        {

        }
        public BasicWeek(int weekNum)
        {
            WeekNum = weekNum;
        }
    }
}
