using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportScheduleConsole
{
    public interface ITeamSet
    {
        public List<ITeam> Teams { get; set; }
        virtual void AddTeam(ITeam team)
        {
            Teams.Add(team);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>boolean indicating success</returns>
        public bool DoOpponents(int season_length);
        public bool ValidateSet(int season_length);
        public virtual void Randomize()
        {
            Teams = Helpers.Shuffle(Teams).ToList();
            Teams.ForEach(t => t.Opponents = Helpers.Shuffle(t.Opponents).ToList());
        }
    }
}
