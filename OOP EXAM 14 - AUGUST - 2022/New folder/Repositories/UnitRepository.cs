using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private readonly List<IMilitaryUnit> models;

        public UnitRepository()
        {
            models = new List<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models => models.AsReadOnly();

        public void AddItem(IMilitaryUnit model)
        {
           models.Add(model);

            
        }

        public IMilitaryUnit FindByName(string name)
        {
            IMilitaryUnit unit = models.FirstOrDefault(u => u.GetType().Name == name);
            return unit;
        }

        public bool RemoveItem(string name)
        {
            IMilitaryUnit unit = models.FirstOrDefault(u => u.GetType().Name == name);

            if (unit != null)
            {
                models.Remove(unit);
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
