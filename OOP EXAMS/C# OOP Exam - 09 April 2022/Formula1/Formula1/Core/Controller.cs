using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;

        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            carRepository = new FormulaOneCarRepository();
        }


        public string AddCarToPilot(string pilotName, string carModel)
        {
            var pilot = pilotRepository.FindByName(pilotName);
            if (pilot == null || (pilot != null && pilot.Car != null))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }
            var car = carRepository.FindByName(carModel);

            if (car == null )
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            pilot.AddCar(car);
            return $"Pilot {pilotName} will drive a {car.GetType().Name} {carModel} car.";

        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            var race = raceRepository.FindByName(raceName);
            if (race == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            var pilot = pilotRepository.FindByName(pilotFullName);
            if (pilot == null || (pilot != null && pilot.CanRace == false) || (pilot != null && race.Pilots.Any(p => p.FullName == pilotFullName)))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            race.AddPilot(pilot);

            return $"Pilot {pilotFullName} is added to the {raceName} race.";


        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (type != "Ferrari" && type != "Williams")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            }
            if (carRepository.Models.Any(c => c.Model == model))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CarExistErrorMessage, model));

            }

            IFormulaOneCar car = null;

            if (type is "Ferrari")
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            if (type is "Williams")
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }

            carRepository.Add(car);

            return $"Car {car.GetType().Name}, model {car.Model} is created.";
        }

        public string CreatePilot(string fullName)
        {
            if (pilotRepository.Models.Any(p => p.FullName == fullName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotExistErrorMessage, fullName));

            }

            var pilot = new Pilot(fullName);

            pilotRepository.Add(pilot);

            return $"Pilot {fullName} is created.";

        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (raceRepository.Models.Any(r => r.RaceName == raceName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExistErrorMessage, raceName));

            }

            IRace race = new Race(raceName, numberOfLaps);

            raceRepository.Add(race);
            return $"Race {raceName} is created.";
        }

        public string PilotReport()
        {

            StringBuilder sb = new StringBuilder();
            foreach (var item in pilotRepository.Models.OrderByDescending(p => p.NumberOfWins))
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string RaceReport()
        {

            StringBuilder sb = new StringBuilder();

            foreach (var race in raceRepository.Models.Where(r =>r.TookPlace == true))
            {
                sb.AppendLine(race.RaceInfo().ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string StartRace(string raceName)
        {




            var race = raceRepository.FindByName(raceName);

            if (race == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }

            if (race.TookPlace == true)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            List<IPilot> pilots = new List<IPilot>();

            foreach (var pilot in race.Pilots.Where(p => p.CanRace == true))
            {
                pilots.Add(pilot);
            }

            pilots = pilots.OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps)).Take(3).ToList();

            race.TookPlace = true;

            int count = 1;


            StringBuilder sb = new StringBuilder();
            foreach (var pilot in pilots)
            {
                 
                if (count == 1)
                {
                    pilot.WinRace();
                    sb.AppendLine( $"Pilot {pilot.FullName} wins the {race.RaceName} race.");
                }
                else if (count == 2)
                {
                    sb.AppendLine( $"Pilot {pilot.FullName } is second in the { race.RaceName } race.");
                }
                else if (count == 3)
                {
                    sb.AppendLine( $"Pilot { pilot.FullName } is third in the { race.RaceName } race.");
                }
                
                count++;
            }

            
            return sb.ToString().TrimEnd();
            
        }
    }
}
