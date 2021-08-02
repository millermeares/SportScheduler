using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace SportScheduleConsole
{
    public interface IWeek
    {
        public int WeekNum { get; set; }
        public List<IGame> Games { get; set; }

        virtual void AddGame(IGame game)
        {
            Games.Add(game);
        }
        virtual bool ValidAssignment(ITeam team1, ITeam team2)
        {
            // doing this to avoid having to put the orders on the team.
            if(HasTeam(team1) || HasTeam(team2))
            {
                return false;
            }
            return true;
        }

        virtual bool HasTeam(ITeam team)
        {
            foreach(var game in Games)
            {
                if(game.HasTeam(team))
                {
                    return true;
                }
            }
            return false;
        }

        //todo: bye weeks mean that expected games might be different.
        public virtual bool IsComplete(int expectedGames)
        {
            if(Games.Count != expectedGames)
            {
                return false;
            }
            for (int i = 0; i < Games.Count; i++)
            {
                if (!Games[i].Assigned)
                {
                    return false;
                }
            }

            
            return true;
        }

        virtual bool RemoveGame(IGame game)
        {
            return Games.Remove(game);
        }

        virtual bool ContainsEquivalentGame(IWeek week2)
        {
            foreach(IGame game2 in week2.Games)
            {
                if(ContainsEquivalentGame(game2))
                {
                    return true;
                }
            }
            return false;
        }

        virtual bool ContainsEquivalentGame(IGame game2)
        {
            foreach(IGame game in Games)
            {
                if(game.IsEquivalent(game2))
                {
                    return true;
                }
            }
            return false;
        }

        public virtual void PrintToConsole(string teamOwner = null)
        {
            Console.WriteLine($"Week {WeekNum}");
            foreach (IGame game in Games)
            {
                if(teamOwner == null || game.Participants.Select(o => o.Owner).Contains(teamOwner))
                {
                    Console.WriteLine(game.ToConsoleString());
                }
            }
        }
    }
}
