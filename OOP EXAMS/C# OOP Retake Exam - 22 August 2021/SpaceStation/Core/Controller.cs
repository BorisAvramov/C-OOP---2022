using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private AstronautRepository astrounats;
        private PlanetRepository planets;

        private int dead;
        private int countExplore;

        public Controller()
        {
            astrounats = new AstronautRepository();
            planets = new PlanetRepository();
            dead = 0;
            countExplore = 0;
        }

        public string AddAstronaut(string type, string astronautName)
        {
            if (type != "Biologist" && type != "Geodesist" && type != "Meteorologist")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }
            IAstronaut astro = null;

            if (type == "Biologist")
            {
                astro = new Biologist(astronautName);
            }
            else if (type == "Geodesist")
            {
                astro = new Geodesist(astronautName);

            }
            else if (type == "Meteorologist")
            {
                astro = new Meteorologist(astronautName);
            }

            astrounats.Add(astro);

            return $"Successfully added {type}: {astronautName}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            foreach (var item in items)
            {
                planet.Items.Add(item);

            }

            planets.Add(planet);
            return $"Successfully added Planet: {planetName}!";
        }

        

        public string ExplorePlanet(string planetName)
        {
            var suitableAstros = astrounats.Models.Where(a => a.Oxygen > 60).ToList();
            var planet = planets.Models.FirstOrDefault(p => p.Name == planetName);

            if (suitableAstros.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }
            Mission mission = new Mission();
            
            mission.Explore(planet, suitableAstros);
            countExplore++;

            
            foreach (var astro in suitableAstros)
            {
                if (astro.Oxygen <= 0)
                {
                    dead++;
                }
            }


            return $"Planet: {planetName} was explored! Exploration finished with {dead} dead astronauts!";
        }

        public string Report()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{countExplore} planets were explored!");
            sb.AppendLine("Astronauts info:");
            foreach (var astro in astrounats.Models)
            {
                sb.AppendLine($"Name: {astro.Name}");
                sb.AppendLine($"Oxygen: {astro.Oxygen}");
                string result = astro.Bag.Items.Count > 0 ? string.Join(", ", astro.Bag.Items) : "none";
                sb.AppendLine($"Bag items: {result}");
            }
            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            if (!astrounats.Models.Any( a => a.Name == astronautName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }
            IAstronaut astro = astrounats.Models.FirstOrDefault(a => a.Name == astronautName);

            astrounats.Remove(astro);

            return $"Astronaut {astronautName} was retired!";
        }
    }
}
