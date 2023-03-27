using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly List<IWeapon> models;


        public WeaponRepository()
        {
            models = new List<IWeapon>();
            
        }
        
        public IReadOnlyCollection<IWeapon> Models => models.AsReadOnly();



        public void AddItem(IWeapon model)
        {
            models.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            IWeapon weapon = models.FirstOrDefault(w => w.GetType().Name == name);
            return weapon;
        }

        public bool RemoveItem(string name)
        {
            IWeapon weapon = models.FirstOrDefault(w => w.GetType().Name == name);
            if (weapon != null)
            {
                models.Remove(weapon);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
