﻿using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps ;
        private bool tookPlace;
        private  List<IPilot> pilots;

        public Race(string raceName, int numberOfLaps)
        {
            this.RaceName = raceName;
            this.NumberOfLaps = numberOfLaps;
            tookPlace = false;
            pilots = new List<IPilot>();
        }



        public bool TookPlace
        {
            get { return tookPlace; }
            set { tookPlace = value; }
        }


        public int NumberOfLaps 
        {
            get { return numberOfLaps ; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value));
                }
                numberOfLaps  = value;
            }
        }


        public string RaceName 
        {
            get { return raceName; }
           private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }
                raceName = value;
            }
        }






        public ICollection<IPilot> Pilots => pilots;

        public void AddPilot(IPilot pilot)
        {
            pilots.Add(pilot);
        }

        public string RaceInfo()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The {raceName} race has:");
            sb.AppendLine($"Participants: {pilots.Count}");
            sb.AppendLine($"Number of laps: {numberOfLaps}");
            string result = tookPlace == true ? "Yes" : "No";
            sb.AppendLine($"Took place: {result}");
            return sb.ToString().TrimEnd();

        }
    }
}