using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportScheduleConsole.Teams
{
    public class BasicTeamSet : ITeamSet
    {
        public List<ITeam> Teams { get; set; }
        public BasicTeamSet(List<ITeam> teams)
        {
            Teams = teams;
        }

        public bool DoOpponents(int season_length)
        {
            // no divisions. 
            throw new NotImplementedException();
        }

        public bool ValidateSet(int season_length)
        {
            throw new NotImplementedException();
        }

        //public void Randomize()
        //{
        //    Teams = Helpers.Shuffle(Teams).ToList();
        //    Teams.ForEach(t => t.Opponents = Helpers.Shuffle(t.Opponents).ToList());
        //}
    }
}
