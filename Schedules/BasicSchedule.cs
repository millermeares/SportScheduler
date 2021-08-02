using System;
using System.Collections.Generic;
using System.Text;

namespace SportScheduleConsole
{
    public class BasicSchedule : ISchedule
    {
        public ITeamSet TeamSet { get; set; }
        public List<IWeek> Weeks { get; set; }
        public int SeasonLength { get; set; }

        public BasicSchedule(int seasonlength, ITeamSet teams)
        {
            TeamSet = teams;
            SeasonLength = seasonlength;
            Weeks = new List<IWeek>(seasonlength);
            while(SeasonLength != Weeks.Count) // init week list to correct length. 
            {
                Weeks.Add(new BasicWeek(Weeks.Count + 1));
            }
        }

        // two distinct steps. first, assign teams a set of opponents. second, assign them a schedule. 
        public bool GenerateSchedule()
        {
            if(TeamSet == null)
            {
                throw new NullReferenceException("null teamset");
            }
            if(SeasonLength < 0)
            {
                throw new InvalidCastException("season length less than 0");
            }
            if(!TeamSet.DoOpponents(SeasonLength))
            {
                return false;
            }
            TeamSet.Randomize();
            return AssignWeeks();
        }

        
        public bool AssignWeeks()
        {
            // could go ahead and implement this. it's pretty easy and mostly unrelated to other stuff. it's just backtracking.
            if(IsComplete())
            {
                return true;
            }
            foreach(IWeek week in Weeks)
            {
                if(week.IsComplete(TeamSet.Teams.Count / 2))
                {
                    continue;
                }
                foreach(ITeam team in TeamSet.Teams)
                {
                    foreach(ITeam opponent in team.OpponentsToSchedule())
                    {
                        if(!ValidAssignment(week, team, opponent))
                        {
                            continue;
                        }
                        IGame game = team.GetGame(opponent);
                        team.ScheduledOpponents.Add(opponent);
                        opponent.ScheduledOpponents.Add(team);
                        week.AddGame(game);
                        if(AssignWeeks())
                        {
                            return true;
                        }
                        // else - assign works didn't work. undo the assignments.
                        team.ScheduledOpponents.Remove(opponent);
                        opponent.ScheduledOpponents.Remove(team);
                        week.RemoveGame(game);
                    }
                    // if a week still doesn't have this team, return false.
                    if(!week.HasTeam(team))
                    {
                        return false;
                    }
                }
                // if a week still isn't complete, return false..
                if(!week.IsComplete(TeamSet.Teams.Count / 2))
                {
                    return false;
                }
            }
            return false;
        }
        //temp goal: it should never get past the week without that week being incomplete. 
        public bool ValidAssignment(IWeek week, ITeam team1, ITeam team2)
        {
            // if not the first week, check for back to back equivalent games.
            if(week.WeekNum != 1)
            {
                if(Weeks[week.WeekNum-2].ContainsEquivalentGame(team1.GetGame(team2)))
                {
                    return false;
                }
            }
            if(week.HasTeam(team1) || week.HasTeam(team2))
            {
                return false;
            }
            return true;
        }

        public void PrintScheduleToConsole(string teamOwner = null)
        {
            foreach(IWeek week in Weeks)
            {
                week.PrintToConsole(teamOwner);
                Console.WriteLine();
            }
        }

        public bool IsComplete()
        {
            // if a week is scheduled and incomplete, return false. 
            foreach(IWeek week in Weeks)
            {
                if(!week.IsComplete(TeamSet.Teams.Count / 2))
                {
                    //Console.WriteLine($"incomplete week {week.WeekNum}");
                    return false;
                }
            }
            return true;
        }
    }
}
