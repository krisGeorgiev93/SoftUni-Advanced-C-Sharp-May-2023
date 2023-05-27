using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Guild
{
    public class Guild
    {
        public List<Player> roster;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return roster.Count; } }

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            if (Capacity > roster.Count)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            return roster.Remove(roster.FirstOrDefault(player => player.Name == name));
        }

        public void PromotePlayer(string name)
        {
            if (roster.Any(p => p.Name == name))
            {
                roster.FirstOrDefault(p => p.Name == name).Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            roster.FirstOrDefault(p => p.Name == name).Rank = "Trial";
        }

        public Player[] KickPlayersByClass(string @class)
        {
            var playersToRemove = roster.FindAll(p => p.Class == @class);
            roster.RemoveAll(p => p.Class == @class);
            return playersToRemove.ToArray();
        }

        public string Report()
        {
            return $"Players in the guild: {Name}{Environment.NewLine}{string.Join(Environment.NewLine, roster)}";
        }
    }

}