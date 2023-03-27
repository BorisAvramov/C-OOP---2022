using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.name = name;
            this.players = new List<Player>();
        }
        public string Name
        {
            get { return name; }
          private  set 
          {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("A name should not be empty.");
                }

                name = value;
          }
        
        
        }

        public int Stats
        =>  players.Any()?  (int)Math.Round(players.Average(p=>p.Stats)) : 0;


        public void AddPlayer(Player player)
        {
            players.Add(player);

        }
        public bool RemovePlayer(string namePl)
        {
            if (players.Any(p=>p.Name == namePl))
            {
                players.Remove(players.Where(p => p.Name == namePl).FirstOrDefault());
                return true;
            }
            else
            {
                return false;
            }
           
        }
    }
}
