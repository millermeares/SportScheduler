using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace SportScheduleConsole
{
    public class BasicTeam : ITeam, IEquatable<BasicTeam>
    {
        public string Owner { get; set; }
        public string Name { get; set; }
        public List<ITeam> Opponents { get; set; } = new List<ITeam>();
        public List<ITeam> ScheduledOpponents { get; set; } = new List<ITeam>();
        public int Division { get; set; } = -1;

        public BasicTeam(string owner, string name)
        {
            Owner = owner;
            Name = name;
        }

        public bool Equals([AllowNull] BasicTeam other)
        {
            if(other == null)
            {
                return false;
            }
            return other.Owner.Equals(Owner) && other.Name.Equals(Name);
        }

        public IGame GetGame(ITeam other_team)
        {
            return new BasicGame(this, other_team);
        }
    }
}
