using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportScheduleConsole
{
    public interface ISchedule
    {
        public ITeamSet TeamSet { get; set; }
        public List<IWeek> Weeks { get; set; }
        public int SeasonLength { get; set; }
        public bool GenerateSchedule();
        public bool AssignWeeks();
        public void PrintScheduleToConsole(string teamOwner = null);
        public bool IsComplete();
        public virtual void RandomizeWeeks()
        {
            Weeks = Helpers.Shuffle(Weeks).ToList();
            for (int i = 0; i < Weeks.Count; i++)
            {
                Weeks[i].WeekNum = i + 1;
            }
        }

        public virtual bool ContainsEquivalentConsecutiveGames()
        {
            for (int i = 1; i < Weeks.Count - 1; i++)
            {
                if (Weeks[i - 1].ContainsEquivalentGame(Weeks[i]) || Weeks[i].ContainsEquivalentGame(Weeks[i - 1]))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
