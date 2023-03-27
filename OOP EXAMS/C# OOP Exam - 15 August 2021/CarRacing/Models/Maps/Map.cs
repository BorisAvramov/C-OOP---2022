using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {

        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }
            if (racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                racerOne.Race();
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);

            }
            if (!racerOne.IsAvailable() && racerTwo.IsAvailable())
            {
                racerTwo.Race();
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);

            }

            if (racerOne.IsAvailable() && racerTwo.IsAvailable())
            {
                racerOne.Race();
                racerTwo.Race();

                double multiplierOne = racerOne.RacingBehavior == "strict" ? 1.2 : 1.1;
                double multiplierTwo = racerTwo.RacingBehavior == "strict" ? 1.2 : 1.1;


                double chanceWinRacerOne = racerOne.Car.HorsePower * racerOne.DrivingExperience * multiplierOne;
                double chanceWinRacerTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * multiplierTwo;

                

                if (chanceWinRacerOne > chanceWinRacerTwo)
                {
                    return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
                }
                if (chanceWinRacerOne < chanceWinRacerTwo)
                {
                    return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerTwo.Username);

                }

            }

            return null;
        }
    }
}
