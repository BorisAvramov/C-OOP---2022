using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {

        private readonly List<IPlanet> models;

        public PlanetRepository()
        {
            models = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => models.AsReadOnly();



        public void AddItem(IPlanet model)
        {
            models.Add(model);

        }

        public IPlanet FindByName(string name)
        {
            IPlanet planet = models.FirstOrDefault(p => p.Name == name);
            return planet;


        }

        public bool RemoveItem(string name)
        {
            IPlanet planet = models.FirstOrDefault(p => p.Name == name);

            if (planet != null)
            {
                models.Remove(planet);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
