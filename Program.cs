using System;
using System.Collections.Generic;
using System.Linq;

namespace SportScheduleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // constraint satisfaction problem. 
            // backtracking search.

            // at each level we will assign a value to a variable. 

            // depth first search using the constraints. 
            // at each level, we will assign a value to a variable. 

            // backtrack when there are no more 'legal' assignments.

            // league: 
            // teams, number of weeks
            // number of divisions?

            // team:
            // property: division, schedule 

            // schedule:
            // ability to check legal assignment?
            // underlying data structure is a sorted list?

            // game? week? 


            // 1. get everyone's opponents. that's ez at least for 14 games and 11 potential opponents with 3 division opponents 
            // 2. 


            // do it by team. each team's full schedule first. then put those into weeks. then randomize the order and voila. 
            DivisionTeam noah = new DivisionTeam("noah", "Team nberens", 1);
            DivisionTeam court = new DivisionTeam("court", "Team cmauzyiv", 1);
            DivisionTeam stephen = new DivisionTeam("stephen", "Team sAARONdipity", 1);
            DivisionTeam jon = new DivisionTeam("jon", "Double Tre", 1);
            DivisionTeam michael = new DivisionTeam("michael", "Josh All-In", 2);
            DivisionTeam josiah = new DivisionTeam("josiah", "Team josiahdayton", 2);
            DivisionTeam killen = new DivisionTeam("killen", "Chris Herndon IV StringTE", 2);
            DivisionTeam jackson = new DivisionTeam("jackson", "Taysom Tots", 2);
            DivisionTeam miller = new DivisionTeam("miller", "Cincinatti Bengals", 3);
            DivisionTeam harrison = new DivisionTeam("harrison", "The Najee Dog Pissers", 3);
            DivisionTeam christian = new DivisionTeam("christian", "Plz make me an offer", 3);
            DivisionTeam josh = new DivisionTeam("josh", "ASAP FIRK", 3);
            List<DivisionTeam> teams = new List<DivisionTeam>(){ noah, court, stephen, jon, michael, josiah, killen, jackson, miller, harrison,
            christian, josh};
            DivisionTeamSet team_set = new DivisionTeamSet(teams, 2);
            try
            {
                Console.WriteLine("starting");
                ISchedule schedule = new BasicSchedule(14, team_set);
                if (!schedule.GenerateSchedule())
                {
                    Console.WriteLine("something went wrong");
                }
                schedule.PrintScheduleToConsole();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
