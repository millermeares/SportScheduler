using System;
using System.Collections.Generic;
using System.Text;

namespace SportScheduleConsole
{
    public class DivisionTeam : BasicTeam
    {
        public DivisionTeam(string owner, string name, int division)
            :base(owner, name)
        {
            Division = division;
        }
    }
}
