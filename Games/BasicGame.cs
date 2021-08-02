using System;
using System.Collections.Generic;
using System.Text;

namespace SportScheduleConsole
{
    public class BasicGame : IGame
    {
        public List<ITeam> Participants { get; set; }
        public int ParticipantsPerGame { get; set; } = 2;
        public BasicGame(ITeam team1, ITeam team2)
        {
            Participants = new List<ITeam>() { team1, team2 };
        }
    }
}
