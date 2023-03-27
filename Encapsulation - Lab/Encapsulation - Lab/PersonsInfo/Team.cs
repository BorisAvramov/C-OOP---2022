﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private  string name;
        private  List<Person> firstTeam;
        private List<Person> reserveTeam;

     
        public Team(string name)
        {
            this.name = name;
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();   


        }

        public string Name => this.name;

        public IReadOnlyCollection<Person> FirstTeam => firstTeam;
        public IReadOnlyCollection<Person> ReserveTeam => reserveTeam;

        public void AddPlayer(Person person) 
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
                
        
        }

    }
}
