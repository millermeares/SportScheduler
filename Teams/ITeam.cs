using System;
using System.Collections.Generic;
using System.Text;

namespace SportScheduleConsole
{
    public interface ITeam
    {
        public string Owner { get; set; }
        public string Name { get; set; }
        public List<ITeam> Opponents { get; set; }
        public List<ITeam> ScheduledOpponents { get; set; }
        public int Division { get; set; }

        public virtual List<ITeam> OpponentsToSchedule()
        {
            List<ITeam> opponents_to_schedule = new List<ITeam>(Opponents);
            foreach (var team in ScheduledOpponents)
            {
                // remove first instance of the team from scheduled opponents
                opponents_to_schedule.Remove(team);
            }
            return opponents_to_schedule;
        }
        public bool CanScheduleTeam(ITeam team2)
        {
            return OpponentsToSchedule().Contains(team2);
        }

        public IGame GetGame(ITeam team);
    }
}
