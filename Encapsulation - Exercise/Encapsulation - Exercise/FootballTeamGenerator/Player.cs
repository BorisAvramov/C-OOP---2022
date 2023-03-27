using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

      


        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            Validator.CheckStat("Endurance", endurance);
            Validator.CheckStat("Sprint", sprint);
            Validator.CheckStat("Dribble", dribble);
            Validator.CheckStat("Passing", passing);
            Validator.CheckStat("Shooting", shooting);


            this.endurance = endurance;
            this.sprint = sprint;
            this.dribble = dribble;
            this.passing = passing;
            this.shooting = shooting;
        }

        public double Stats => (endurance + sprint + dribble + passing + shooting) / 5.0;
       
        public string Name
        {
            get { return name; }
           private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("A name should not be empty.");
                }
                name = value;
            }
        }



    }
}
