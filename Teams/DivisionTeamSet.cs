using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportScheduleConsole
{
    public class DivisionTeamSet : ITeamSet
    {
        public string ErrorString { get; set; }
        public List<ITeam> Teams { get; set;}
        public int DivisionOpponentGames { get; }
        public List<int> DistinctDivisions
        {
            get
            {
                return Teams.Select(t => t.Division).Distinct().ToList();
            }
        }

        public int TeamsPerDivision => Teams.Count / DistinctDivisions.Count;
        
        public DivisionTeamSet(List<DivisionTeam> teams, int division_opponent_games)
        {
            Teams = new List<ITeam>(teams);
            DivisionOpponentGames = division_opponent_games;
        }
        public bool DoOpponents(int season_length)
        {
            // each team has 'potential opponents of
            // mandate division opponents.
            if(DivisionOpponentGames * (TeamsPerDivision- 1) + Teams.Count - TeamsPerDivision == season_length)
            {
                // sick. 
                foreach(ITeam team in Teams)
                {
                    team.Opponents = Teams.Where(t => (t.Division == team.Division && t.Name != team.Name && t.Owner != team.Owner) || team.Division != t.Division).ToList();
                }
                int j = DivisionOpponentGames - 1;
                while (j > 0)
                {
                    j--;
                    foreach (ITeam team in Teams)
                    {
                        team.Opponents.AddRange(Teams.Where(t => t.Division == team.Division && t.Name != team.Name && t.Owner != team.Owner).ToList());
                    }
                }
            }
            return true;
        }

        public bool ValidateSet(int season_length)
        {
            if(season_length <= 0)
            {
                // season must be < =
                ErrorString = "season must have at least one game";
                return false;
            }
            if(DivisionOpponentGames * (TeamsPerDivision - 1) < season_length)
            {
                ErrorString = "season must be long enough to fulfill division constraints";
                return false;
            }
            return true;
        }
    }
}
