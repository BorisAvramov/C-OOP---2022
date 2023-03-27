using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;


        public Controller()
        {
            cars = new CarRepository();
            racers = new RacerRepository();
            map = new Map();
        }



        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            if (type != "SuperCar" && type != "TunedCar")
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }
            ICar car = null;

            if (type == "SuperCar")
            {
                car = new SuperCar(make, model, VIN, horsePower);
            }
            if (type == "TunedCar")
            {
                car = new TunedCar(make, model, VIN, horsePower);

            }

            cars.Add(car);
            return String.Format(OutputMessages.SuccessfullyAddedCar, car.Make, car.Model, car.VIN);

        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar car = cars.FindBy(carVIN);

            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }
            if (type != "ProfessionalRacer" && type != "StreetRacer")
            {
                throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }

            IRacer racer = null;
            if (type == "ProfessionalRacer")
            {
                racer = new ProfessionalRacer(username, car);
            }
            if (type == "StreetRacer")
            {
                racer = new StreetRacer(username, car);

            }

            racers.Add(racer);

            return String.Format(OutputMessages.SuccessfullyAddedRacer, username);

        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racer1 = racers.FindBy(racerOneUsername);
            IRacer racer2 = racers.FindBy(racerTwoUsername);

            if (racer1 == null || racer2 == null)
            {
                string userNull = string.Empty;

                if (racer1 == null)
                {
                    userNull = racerOneUsername;
                }
               else if (racer2 == null)
                {
                    userNull = racerTwoUsername;
                }

                throw new ArgumentException(String.Format(ExceptionMessages.RacerCannotBeFound, userNull));

            }

            return map.StartRace(racer1, racer2);

        }

        public string Report()
        {

            StringBuilder sb = new StringBuilder();

            foreach (var racer in racers.Models.OrderByDescending(m => m.DrivingExperience).ThenBy(m => m.Username))
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().TrimEnd();

        }
    }
}
