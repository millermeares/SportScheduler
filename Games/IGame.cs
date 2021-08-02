using System;
using System.Collections.Generic;
using System.Text;

namespace SportScheduleConsole
{
    public interface IGame
    {
        List<ITeam> Participants { get; set; }
        int ParticipantsPerGame { get; set; }
        virtual bool HasTeam(ITeam team1)
        {
            return Participants.Contains(team1);
        }
        public bool Assigned
        {
            get => Participants.Count == ParticipantsPerGame;
        }
        virtual string ToConsoleString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for(int i = 0; i < Participants.Count; i++)
            {
                sb.Append(Participants[i].Owner);
                if(i != Participants.Count - 1)
                {
                    sb.Append(" vs. ");
                }
            }
            return sb.ToString();
        }

        virtual bool IsEquivalent(IGame game2)
        {
            if(ParticipantsPerGame != game2.ParticipantsPerGame)
            {
                return false;
            }
            foreach(ITeam team in Participants)
            {
                if(!game2.Participants.Contains(team))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
