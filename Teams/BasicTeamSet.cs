using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportScheduleConsole.Teams
{
    public class BasicTeamSet : ITeamSet
    {
        public List<ITeam> Teams { get; set; }
        public string ErrorString { get; set; }

        public BasicTeamSet(List<ITeam> teams)
        {
            Teams = teams;
        }

        public bool DoOpponents(int season_length)
        {
            // no divisions. 
            // circle would be fine right? no - too much carry-over.
            throw new NotImplementedException();
        }

        public bool ValidateSet(int season_length)
        {
            // get rid of the easy things. like if ... season_length < 0 or whatever
            if(season_length <= 0)
            {
                return false;
            }
            return true;
        }
    }
}
